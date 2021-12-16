using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{
    public bool canAttack = true;
    public bool input;
    PlayerMovement player;
    Animator anim;
    DamageCollider dmg;
    public int attack;
    public bool combo;
    public int mana, maxMana;
    public int baseDamage, baseKnockback;
    public HealthAndManaManager manaSlider;
    float timer;
    private void Start()
    {
        player = transform.parent.parent.GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        dmg = GetComponent<DamageCollider>();
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        input = player.input;
        if (!input) return;
        manaSlider.maxMana = maxMana;
        manaSlider.mana = mana;
        anim.SetFloat("X", Input.GetAxisRaw("Vertical") == 0 ? 1 : 0);
        anim.SetFloat("Y", Input.GetAxisRaw("Vertical"));
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
        if (Input.GetKeyDown(KeyCode.C) && canAttack)
        {
            if(attack == 0) attack = 1;
            if(combo) attack = 2;
        }
        if (Input.GetKeyDown(KeyCode.X) && attack != 3)
        {
            if (mana > 0)
            {
                Camera.main.GetComponent<SoundManager>().PlaySound(2);
                mana--;
                attack = 3;
            }
        }
        anim.SetInteger("Attack", attack);

    }
}
