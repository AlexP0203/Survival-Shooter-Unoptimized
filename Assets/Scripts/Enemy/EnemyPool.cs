using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] int zombieAmount;
    [SerializeField] EnemyData spawnTime;   
    [SerializeField] EnemyData spawnDelay;
    [SerializeField] PlayerStats playerHealth;

    public GameObject enemy;
    Queue<GameObject> remainingEnemies = new Queue<GameObject>();


    void Start()
    {

        for (int i = 0; i < zombieAmount; i++)
        {
            var b = Instantiate(enemy);
            b.GetComponent<AddToPool>().setPool(this);
            b.gameObject.SetActive(false);
        }
        InvokeRepeating("Spawn", spawnDelay.spawnDelay, spawnTime.spawnTime);
    }

    void Spawn()
    {
       if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        if (remainingEnemies.Count > 0)
        {
            var current = remainingEnemies.Dequeue();

            current.gameObject.SetActive(true);
        }
    }

    public void AddToQueue(GameObject b)
    {
        remainingEnemies.Enqueue(b);
    }
}
