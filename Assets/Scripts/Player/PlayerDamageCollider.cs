using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCollider : DamageCollider
{
    public int damageModifier;
    public PlayerAttacks attacker;
    List<GameObject> attacked = new List<GameObject> { };
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;
        foreach (GameObject instance in attacked)
        {
            if (collision.gameObject == instance) return;
        }
        attacked.Add(collision.gameObject);
        
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.Damage(damage, Input.GetAxisRaw("Vertical") == 0 ? PlayerMovement.instance.GetComponent<Collider2D>() : collision, knockback);
            Camera.main.GetComponent<SoundManager>().PlaySound(1);
            if (me.TryGetComponent(out PlayerMovement player))
            {
                player.airDashed = false;
                player.registerMove = false;
                me.velocity = new Vector2(Input.GetAxisRaw("Vertical") == 0 ? -me.GetComponent<PlayerMovement>().lastMove / 2 : 0, -Input.GetAxisRaw("Vertical") * 1.7f) * knockback;
            }
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.isTrigger) return;
        OnTriggerEnter2D(collision.collider);
    }
    private void Update()
    {
        if (!GetComponent<Collider2D>().enabled) attacked.Clear();
        damage = attacker.baseDamage + damageModifier;
        knockback = attacker.baseKnockback;
    }
}
