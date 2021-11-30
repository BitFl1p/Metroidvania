using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndManaManager : MonoBehaviour
{
    public int health, maxHealth, mana, maxMana;
    public List<Animator> healthContainers;
    public List<Animator> manaContainers;
    private void Update()
    {
        int count = 0;
        foreach (Animator anim in healthContainers)
        {
            if (maxHealth - count <= 0) anim.gameObject.SetActive(false);
            else anim.gameObject.SetActive(true);
            if (health - count <= 0) anim.SetBool("Full", false);
            else anim.SetBool("Full", true);
            count++;
        }
        count = 0;
        foreach (Animator anim in manaContainers)
        {
            if (maxMana - count <= 0) anim.gameObject.SetActive(false);
            else anim.gameObject.SetActive(true);
            if (mana - count <= 0) anim.SetBool("Full", false);
            else anim.SetBool("Full", true);
            count++;
        }
    }
}
