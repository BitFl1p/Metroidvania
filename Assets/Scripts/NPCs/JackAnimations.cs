using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackAnimations : MonoBehaviour
{
    DialogueTrigger dialogue;
    Animator anim;
    private void Start()
    {
        dialogue = GetComponent<DialogueTrigger>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(DialogueManager.instance.anim.GetBool("Dialoguing") && DialogueManager.instance.sentences.Count > 0)
        {
            if(DialogueManager.instance.sentences.Peek() == dialogue.dialogue[0].lines[1].sentence) anim.SetInteger("Scare", 2);
            else if (DialogueManager.instance.sentences.Peek() == dialogue.dialogue[0].lines[2].sentence) anim.SetInteger("Scare", 1);
            else if (DialogueManager.instance.sentences.Peek() == dialogue.dialogue[0].lines[3].sentence) anim.SetInteger("Scare", 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && dialogue.index == 0)
        {
            anim.SetInteger("Scare", 2);
        }
    }
}
