using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VladsUsefulScripts;

public class Enemy : MonoBehaviour
{
    internal Rigidbody2D rb;
    [SerializeField]
    public float drag;
    public HealthContainer healthDrop, manaDrop;
    private void OnDestroy()
    {
        if(PlayerMovement.instance.GetComponent<PlayerHealth>().health < PlayerMovement.instance.GetComponent<PlayerHealth>().maxHealth && Random.Range(1, 11) > 7) Instantiate(healthDrop, transform.position, transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f),1) * 4;
        if(PlayerMovement.instance.attacks.mana < PlayerMovement.instance.attacks.maxMana && Random.Range(1, 11) > 7) Instantiate(manaDrop, transform.position, transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 1) * 4;
    }
    virtual internal void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    virtual internal void FixedUpdate()
    {
        rb.velocity = Clampers.Drag(rb.velocity, drag);
    }
}
