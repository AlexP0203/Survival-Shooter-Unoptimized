using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPool : MonoBehaviour
{
    EnemyPool pool;
    float remainingTime = 0;

    public void OnDisable()
    {
        if (pool != null)
        {
            pool.AddToQueue(gameObject);
        }
    }

    public void setPool(EnemyPool zb)
    {
        pool = zb;
    }
}
