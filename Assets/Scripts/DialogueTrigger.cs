using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasTriggered;

    private void Start()
    {
        hasTriggered = false;
    }

    public void TriggerDialogue()
    {
        hasTriggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !hasTriggered)
        {
            TriggerDialogue();
        }
    }
}
