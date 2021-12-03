using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogue;
    [HideInInspector] public int index = 0;
    bool playerHere;
    
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue[index]);
        if (index >= dialogue.Count - 1) return;
        index++;
    }
    private void Update()
    {
        
        if (playerHere && Input.GetKeyDown(KeyCode.C) && !DialogueManager.instance.anim.GetBool("Dialoguing")) TriggerDialogue();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            PlayerMovement.instance.attacks.canAttack = false;
            CButton.instance.sprite.enabled = true;
            playerHere = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            CButton.instance.sprite.enabled = false;
            playerHere = false;
            PlayerMovement.instance.attacks.canAttack = true;
        }
    }
}
