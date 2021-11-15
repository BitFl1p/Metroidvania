using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DamageCollider
{
    float timeAlive;
    float speed;
    Vector2 direction;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Destroy(gameObject);
    }
    public void Shoot(Vector2 direction, float speed, int damage, int knockback, float timeAlive)
    {
        me = GetComponent<Rigidbody2D>();
        this.damage = damage;
        this.timeAlive = timeAlive;
        this.knockback = knockback;
        this.direction = direction;
        this.speed = speed;
    }
    private void Update()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive < 0) Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        if (GetComponent<Rigidbody2D>().velocity.y != 0) knockback = 0;
    }

    
}
