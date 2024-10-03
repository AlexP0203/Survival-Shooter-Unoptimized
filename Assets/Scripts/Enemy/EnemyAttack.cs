using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyData timeBetweenAttacks;
    [SerializeField] EnemyData attackDamage;
    [SerializeField] PlayerStats playerHP;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    int id_playerdead = Animator.StringToHash("PlayerDead");


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks.timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHP.currentHealth <= 0)
        {
            anim.SetTrigger (id_playerdead);
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHP.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage.attackDamage);
        }
    }
}
