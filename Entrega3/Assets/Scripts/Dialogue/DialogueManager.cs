using Cinemachine;
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

    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera dialogueCamera;

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

    public void EndDialogue()
    {
        HideDialogue();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Cambiar de vuelta a la cámara principal
        mainCamera.Priority = 10;
        dialogueCamera.Priority = 5;
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
        dialogueAnimator.SetBool("Show", true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Cambiar a la cámara de diálogo
        mainCamera.Priority = 5;
        dialogueCamera.Priority = 10;
    }
    public void HideDialogue()
    {
        dialogueAnimator.SetBool("Show", false);
    }
}
