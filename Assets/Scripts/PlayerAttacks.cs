using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    Animator anim;
    DamageCollider dmg;
    int attack;
    public bool combo;
    float timer;
    private void Start()
    {
        anim = GetComponent<Animator>();
        dmg = GetComponent<DamageCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (combo)
        {
            if(attack == 1) attack = 0;
            timer -= Time.deltaTime;
        }
        else
        {
            combo = false;
            timer = 0.4f;
        }
        if (combo && timer < 0)
        {
            combo = false;
            attack = 0;
        }
        anim.SetInteger("Attack", attack);
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(attack == 0) attack = 1;
            if(combo) attack = 2;
        }
        
    }
}
