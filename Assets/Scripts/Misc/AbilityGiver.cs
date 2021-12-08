using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Ability
{
    DASH,
    WALLJUMP,
    MANA
}
public class AbilityGiver : MonoBehaviour
{
    public Transform spikeReset;
    public Spike spike;
    public Ability ability;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Animator>().SetBool("Collected", true);
        }
    }
    public void GiveSkill()
    {
        switch (ability)
        {
            case Ability.DASH:
                PlayerMovement.instance.StartCoroutine(Popup.instance.Pop("Press Shift to Dash", 4));
                PlayerMovement.instance.canDash = true;
                break;
            case Ability.WALLJUMP:
                PlayerMovement.instance.StartCoroutine(Popup.instance.Pop("Press Space while on a wall to Wall Jump", 4));
                PlayerMovement.instance.canWallJump = true;
                break;
            case Ability.MANA:
                PlayerMovement.instance.StartCoroutine(Popup.instance.Pop("Press X to fire a projectile shot. This drains your mana", 4));
                PlayerMovement.instance.attacks.maxMana = 4;
                PlayerMovement.instance.attacks.mana = 4;
                break;
        }
        spike.respawnLocation = spikeReset.position;
        Destroy(gameObject);
    }
}
