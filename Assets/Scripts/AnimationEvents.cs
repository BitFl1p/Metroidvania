using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public void PauseParticle()
    {
        var emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 0;
    }
    public void PlayParticle()
    {
        var emission = GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 15;
    }
    public PlayerAttacks attacks;
    public void DetectAttack()
    {
        attacks.combo = true;
    }
}
