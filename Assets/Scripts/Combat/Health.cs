using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxHealth, health;
    protected Rigidbody2D rb;
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
        if (TryGetComponent(out EnemyPatroller emy)) 
        {
            InvincibilityFrames(emy);
            emy.knockTimer = 0.5f; 
        }
        health -= damage;
        rb.velocity = (Vector2)(transform.position * 10 - dealer.transform.position * 10).normalized * knockback;
    }
    public IEnumerator InvincibilityFrames(EnemyPatroller patrol)
    {
        while(patrol.knockTimer > 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.2f, 0.2f, 0.2f);
            yield return null;
        }
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        yield return null;
    }
}
