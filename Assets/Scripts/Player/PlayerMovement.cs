using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	IA_PlayerActions input;
	float vForce;
	float hForce;
	int id_walking = Animator.StringToHash("IsWalking");


	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
        input = new IA_PlayerActions();
        input.Player.Enable();
    }

    private void Start()
    {
		input.Player.Move.performed += ctx =>
		{
			vForce = input.Player.Move.ReadValue<Vector2>().x * speed;
			hForce = input.Player.Move.ReadValue<Vector2>().y * speed;
        };

		input.Player.Move.canceled += ctx => { hForce = 0.0f; vForce = 0.0f; };
    }

    void FixedUpdate()
	{
        Move(vForce, hForce);
        Turning();
        Animating(vForce, hForce);
    }

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool(id_walking, walking);
	}
}
