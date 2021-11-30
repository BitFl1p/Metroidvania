using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    Animator anim;
    public Projectile playerProjectile;
    public void ResetVel()
    {
        GetComponentInParent<PlayerMovement>().registerMove = false;
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(-GetComponentInParent<PlayerMovement>().lastMove, 0);
    }
    public void RegisterMove()
    {
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(GetComponentInParent<PlayerMovement>().lastMove, 0);
        GetComponentInParent<PlayerMovement>().registerMove = true;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PauseParticle()
    {
        var emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 0;
    }
    public void PlayParticle()
    {
        var emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 50;
    }
    public PlayerAttacks attacks;
    public void DetectAttack()
    {
        attacks.combo = true;
    }
    public void RegisterMoveTrue()
    {
        GetComponentInParent<PlayerMovement>().registerMove = true;
    }
    public void RegisterMoveFalse()
    {
        GetComponentInParent<PlayerMovement>().registerMove = false;
    }

    public void ShootProjectile()
    {
        PlayerMovement schmove = GetComponentInParent<PlayerMovement>();
        PlayerAttacks attac = GetComponentInParent<PlayerAttacks>();
        Instantiate(playerProjectile, transform.position, transform.rotation).Shoot(new Vector2(anim.GetFloat("X") * schmove.lastMove, anim.GetFloat("Y")), schmove.speed * schmove.maxSpeedMult * 4, attac.baseDamage * 2, attac.baseKnockback * 2, 5);
        attac.attack = 0;
    }
}
