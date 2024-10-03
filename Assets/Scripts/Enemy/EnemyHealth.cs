using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyData startingHealth;
    [SerializeField] EnemyData sinkSpeed;
    [SerializeField] EnemyData scoreValue;

    public int currentHealth;
    public AudioClip deathClip;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    int id_dead = Animator.StringToHash("Dead");


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth.startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
           transform.Translate (-Vector3.up * sinkSpeed.sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger (id_dead);

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
        StartCoroutine(setFalse());
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking= true;
        ScoreManager.score += scoreValue.scoreValue;
        Destroy (gameObject, 2f);
    }

    IEnumerator setFalse()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
