using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCollider : DamageCollider
{
    List<GameObject> attacked = new List<GameObject> { };
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject instance in attacked)
        {
            if (collision.gameObject == instance) return;
        }
        attacked.Add(collision.gameObject);
        
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage, GetComponent<Collider2D>(), knockback);
            if (me.TryGetComponent(out PlayerMovement player))
            {
                player.airDashed = false;
                player.registerMove = false;
                me.velocity = new Vector2(Input.GetAxisRaw("Vertical") == 0 ? -me.GetComponent<PlayerMovement>().lastMove : 0, -Input.GetAxisRaw("Vertical")*2.5f) * knockback;
            }
        }
    }
    private void Update()
    {
        if (!GetComponent<Collider2D>().enabled) attacked.Clear();
    }
}
