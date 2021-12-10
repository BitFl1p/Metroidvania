using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    public int health , mana;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health += collision.gameObject.GetComponent<PlayerHealth>().health >= collision.gameObject.GetComponent<PlayerHealth>().maxHealth ? 0 : health;
            collision.gameObject.GetComponent<PlayerMovement>().attacks.mana += collision.gameObject.GetComponent<PlayerMovement>().attacks.mana >= collision.gameObject.GetComponent<PlayerMovement>().attacks.maxMana ? 0 : mana;
            Destroy(gameObject);
        }
    }
}
