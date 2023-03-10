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

        SoundManager.PlaySound(SoundManager.Sound.BossHit);

        if (CurrentHealth <= 0)
        {
            Death();
        }
    }

    public float GetHealthPercentage()
    {
        return CurrentHealth / enemyData.MaxHealth;
    }

    private void Death()
    {
        Destroy(gameObject);
        GameOver.Instance.GameWon();
    }
}
