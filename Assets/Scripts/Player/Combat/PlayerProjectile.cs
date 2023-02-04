using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D RB;

    [SerializeField] private float speed;
    [SerializeField] private float maxLifeTime;
    [SerializeField] private float damage;

    private float lifeTime;

    private void Awake()
    {
        lifeTime = 0;

        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;

        if (lifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetTrajectory(Vector2 trajectory)
    {
        RB.velocity = trajectory * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<EnemyCombatHandler>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
