using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class ArenaCollider : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public List<GameObject> Enemies;
    }
    public List<Wave> waves;
    public List<Animator> doors;
    bool startFight;
    bool disableArena;
    public bool StartFight
    {
        get { return startFight; }
        set 
        { 
            startFight = value;
            foreach (Animator door in doors) door.SetBool("Open", !StartFight);
        }
    }
    private void Start()
    {
        foreach (Animator door in doors) door.SetBool("Open", !StartFight);
    }
    int index = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !disableArena) 
            StartFight = true;
    }
    private void Update()
    {
        if (disableArena) return;
        if (StartFight)
        {
            if(index == 0)
            {
                foreach (GameObject monster in waves[index].Enemies) monster.SetActive(true);
                index++;
            }
            else
            {
                bool enemyAlive = false;
                foreach (GameObject monster in waves[index-1].Enemies) if (monster) enemyAlive = true;
                if (index >= waves.Count && !enemyAlive) 
                { 
                    StartFight = false;
                    disableArena = true;
                    return;
                }
                if (!enemyAlive)
                {
                    foreach (GameObject monster in waves[index].Enemies) monster.SetActive(true);
                    index++;
                }
            }
        }
    }
}
