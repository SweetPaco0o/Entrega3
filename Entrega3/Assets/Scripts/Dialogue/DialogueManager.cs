using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Animator dialogueAnimator;

    public static DialogueManager Instance;

    private DialogueNode _currentNode;

    private GameObject _talker;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI SpeechText;
    public TextMeshProUGUI[] OptionsText;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void StartDialogue(Conversation conversation, GameObject talker)
    {
        _talker = talker;
        _currentNode = conversation.StartNode;
        NameText.text = conversation.Name;
        SetNode(_currentNode);
        ShowDialogue();
    }

    private void SetNode(DialogueNode currentNode)
    {
        SpeechText.text = currentNode.Text;
        for (int i = 0; i < OptionsText.Length; i++)
        {
            if (i < currentNode.Options.Count)
            {
                OptionsText[i].transform.parent.gameObject.SetActive(true);
                OptionsText[i].text = currentNode.Options[i].Text;
            }
            else
            {
                OptionsText[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void ShowDialogue()
    {
        dialogueAnimator.SetBool("Show", true);
    }
    public void HideDialogue()
    {
        dialogueAnimator.SetBool("Show", false);
    }
}