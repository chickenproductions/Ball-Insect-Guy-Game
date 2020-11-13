using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour,IDamage
{
    int maxHealth;
    int currentHealth;
    public CreatureData healthData;
    public UnityEvent onDamage;
    public UnityEvent onDeath;
    void Awake()
    {
        maxHealth = healthData.Health;
        currentHealth = maxHealth;
    }
    public void DamageTo(int Damage, Vector2 location)
    {
        currentHealth -= Damage;
        onDamage.Invoke();
        if (currentHealth < 1)
        {
            onDeath.Invoke();
        }
    }

}
