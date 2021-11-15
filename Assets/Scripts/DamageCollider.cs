using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageCollider : MonoBehaviour
{
    
    public Rigidbody2D me;
    public int damage, knockback;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        OnTriggerEnter2D(collision.collider);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
        collision.gameObject.TryGetComponent(out Health health);
        if (health)
        {
            health.Damage(damage, GetComponent<Collider2D>(), knockback);
            if (collision.TryGetComponent(out PlayerMovement player)) player.registerMove = false;
        }
    }
    
}
