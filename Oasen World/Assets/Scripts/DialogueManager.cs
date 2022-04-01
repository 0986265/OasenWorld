using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        ZoomControl2.instance.ZoomChange(false);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(false);
    }

    public void DisplayNextSentence(bool explain)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(explain)
        {
            DruppieBehaviour.instance.DruppieExplain();
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        ZoomControl2.instance.ZoomChange(true);

        //Temp
        DruppieBehaviour.instance.StartCoroutine(DruppieBehaviour.instance.DruppieGone());
    }
}