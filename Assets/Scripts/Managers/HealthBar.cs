using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerStats current;
    [SerializeField] PlayerStats max;
    [SerializeField] Image bar;

    void Update()
    {
        bar.fillAmount = (float)current.currentHealth / max.startingHealth;
    }
}
