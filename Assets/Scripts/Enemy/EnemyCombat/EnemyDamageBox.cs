using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBox : MonoBehaviour
{
    [SerializeField] private float damage; 

    private void OnTriggerEnter2d(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerCombatHandler>().TakeDamage(damage, (col.transform.position.x - transform.position.x) > 0 ? 1 : -1);
            Debug.Log("bruh");
        }
    }
}
