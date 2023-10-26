using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public bool dialogueRunning;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Start");
        dialogueRunning = true;
        dialogueBox.SetActive(true);
    
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence); 
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End");
        dialogueRunning = false;
        dialogueBox.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && dialogueRunning)
        {
            DisplayNextSentence();
        }
    }
}
