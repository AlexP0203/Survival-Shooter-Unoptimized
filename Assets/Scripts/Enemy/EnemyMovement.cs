using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] PlayerStats playerHealth;

    Transform player;
    EnemyHealth enemyHealth;
    NavMeshAgent enemyAgent;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        enemyHealth = enemyHealth = GetComponent<EnemyHealth>();
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            enemyAgent.SetDestination (player.position);
        }
        else
        {
            enemyAgent.enabled = false;
        }
    }
}
