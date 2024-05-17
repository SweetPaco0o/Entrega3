using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation Conversation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DialogueManager.Instance.StartDialogue(Conversation, gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.Instance.HideDialogue();
        }
    }
}
