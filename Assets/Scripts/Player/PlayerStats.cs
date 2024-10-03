using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Player Data")]
public class PlayerStats : ScriptableObject
{
    public int startingHealth;
    public int currentHealth;
}
