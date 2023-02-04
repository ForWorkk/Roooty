using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatHandler : MonoBehaviour
{
    public float CurrentHealth { get; private set; }

    private EnemyData enemyData;



    public void Initialise(EnemyData enemyData)
    {
        this.enemyData = enemyData;

        CurrentHealth = enemyData.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Death");
    }
}
