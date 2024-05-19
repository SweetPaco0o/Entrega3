using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Animator dialogueAnimator;
    public Animator characterAnimator;

    public static DialogueManager Instance;

    private DialogueNode _currentNode;

    private GameObject _talker;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI SpeechText;
    public TextMeshProUGUI[] OptionsText;

    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera dialogueCamera;

    public AudioSource audioSource;

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

        // Resetear el estado de la animación
        characterAnimator.SetBool("isDancing", false);
    }

    private void SetNode(DialogueNode currentNode)
    {
        SpeechText.text = currentNode.Text;
        PlayNodeAudio(currentNode);
        PlayNodeAnimation(currentNode);

        for (int i = 0; i < OptionsText.Length; i++)
        {
            if (i < currentNode.Options.Count)
            {
                OptionsText[i].transform.parent.gameObject.SetActive(true);
                OptionsText[i].text = currentNode.Options[i].Text;

                // Agregar un listener para cada opción
                int optionIndex = i; // Capturar el índice en una variable local para evitar problemas de cierre
                OptionsText[i].transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
                OptionsText[i].transform.parent.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnOptionSelected(optionIndex));
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

    private void OnOptionSelected(int optionIndex)
    {
        if (optionIndex < _currentNode.Options.Count)
        {
            DialogueNode nextNode = _currentNode.Options[optionIndex].NextNode;
            if (nextNode != null)
            {
                _currentNode = nextNode;
                SetNode(_currentNode);
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void PlayNodeAudio(DialogueNode node)
    {
        if (node.NodeAudio != null)
        {
            audioSource.clip = node.NodeAudio;
            audioSource.Play();
        }
    }

    private void PlayNodeAnimation(DialogueNode node)
    {
        if (characterAnimator != null)
        {
            // Establecer el booleano isDancing en el Animator
            characterAnimator.SetBool("isDancing", node.IsDancing);
        }
    }
}
