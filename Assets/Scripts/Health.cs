using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health;
    [SerializeField] float maxHealth;
    Rigidbody2D rb;
    public DamageIndicator indicator; 
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(int damage, Collider2D dealer, float knockback)
    {
        health -= damage;
        var instance = Instantiate(indicator);
        instance.SetText(damage.ToString());
        instance.transform.position = transform.position;
        rb.velocity += (new Vector2(transform.position.x - dealer.transform.position.x, 0).normalized + Vector2.up*3) * knockback;
    }
}
