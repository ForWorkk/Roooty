using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatHandler : MonoBehaviour
{
    public float CurrentHealth { get; private set; }


    private float invulnerabilityTime;
    private bool isInvulnerable;

    private PlayerData playerData;
    private Player player;

    private void Awake()
    {
        if (CurrentHealth == 0)
        {
            CurrentHealth = 1;
        }
    }

    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTime += Time.deltaTime;

            if (invulnerabilityTime >= playerData.MaxInvulnerabilityTime)
            {
                invulnerabilityTime = 0;

                isInvulnerable = false;
            }
        }
    }

    public void SetData(PlayerData playerData, Player player)
    {
        this.playerData = playerData;
        this.player = player;

        CurrentHealth = playerData.MaxHealth;
    }

    public void TakeDamage(float damage, int dir)
    {
        if (!isInvulnerable)
        {
            SoundManager.PlaySound(SoundManager.Sound.PlayerHit);

            CurrentHealth -= damage;

            player.SetVelocityX(dir * 9);
            player.SetVelocityY(6);

            if (CurrentHealth <= 0)
            {
                Death();
            }

            isInvulnerable = true;
        }
    }

    public float GetHealthPercentage()
    {
        return CurrentHealth / playerData.MaxHealth;
    }

    private void Death()
    {
        Destroy(gameObject);
        GameOver.Instance.GameLost();
    }
}
