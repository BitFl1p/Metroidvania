using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    bool done = true;
    bool faster = false;
    [HideInInspector] public Animator anim;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    [HideInInspector] public Queue<string> sentences = new Queue<string>();
    [HideInInspector] public Queue<string> names = new Queue<string>();
    #region Singleton Shit
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    private void Start()
    {
        anim = PauseMenu.instance.gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (!done && Input.anyKeyDown) faster = true;
        if (Input.anyKeyDown && anim.GetBool("Dialoguing") && done) DisplayNextSentence();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        PlayerMovement.instance.input = false;
        PlayerMovement.instance.attacks.input = false;
        faster = false;
        anim.SetBool("Dialoguing", true);
        sentences.Clear();

        foreach(Dialogue.Line line in dialogue.lines) sentences.Enqueue(line.sentence);
        foreach(Dialogue.Line line in dialogue.lines) names.Enqueue(line.name);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!done) return;
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        nameText.text = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue()
    {
        done = true;
        anim.SetBool("Dialoguing", false);
        PlayerMovement.instance.input = true;
        PlayerMovement.instance.attacks.input = true;
    }
    IEnumerator TypeSentence(string sentence)
    {
        done = false;
        faster = false;
        dialogueText.text = "";
        foreach(char letter in sentence)
        {
            dialogueText.text += letter;
            if(!faster) yield return new WaitForSeconds(0.05f);
            else yield return new WaitForSeconds(0.01f);
        }
        done = true;
    }
}
