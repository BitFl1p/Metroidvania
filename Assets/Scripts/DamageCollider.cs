using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageCollider : MonoBehaviour
{
    public int damage, knockback;
    List<GameObject> attacked = new List<GameObject> { };
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject instance in attacked)
        {
            if (collision.gameObject == instance) return;
        }
        attacked.Add(collision.gameObject);
        collision.gameObject.TryGetComponent(out Health health);
        if (health) health.Damage(damage, GetComponent<Collider2D>(), knockback);
    }
    private void Update()
    {
        if (!GetComponent<Collider2D>().enabled) attacked.Clear();
    }
}
