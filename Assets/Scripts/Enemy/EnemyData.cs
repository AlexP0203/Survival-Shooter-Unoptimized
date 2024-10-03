using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Create Enemy Data")]
public class EnemyData : ScriptableObject
{
    public float spawnTime = 3f;
    public float spawnDelay = 0.1f;

    public int startingHealth = 100;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

}
