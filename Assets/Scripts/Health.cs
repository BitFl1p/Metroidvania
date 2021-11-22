using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth, health;
    protected Rigidbody2D rb;
    public DamageIndicator indicator;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }

    public virtual void Damage(int damage, Collider2D dealer, float knockback)
    {
        health -= damage;
        var instance = Instantiate(indicator);
        instance.SetText(damage.ToString());
        instance.transform.position = transform.position;
        rb.velocity = (Vector2)(transform.position * 10 - dealer.transform.position * 10).normalized * knockback;
    }
}
