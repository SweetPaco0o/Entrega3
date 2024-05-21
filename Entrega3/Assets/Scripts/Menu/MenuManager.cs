using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainPanel;

    //public GameObject gameUI; // Opcional, si tienes una UI de juego que quieres desactivar al pausar

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void GoToMenu()
    {
        optionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void GoToOptions()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void Resume()
    {
        mainPanel.SetActive(false);
        //if (gameUI != null)
        //{
        //    gameUI.SetActive(true);
        //}
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        mainPanel.SetActive(true);
        //if (gameUI != null)
        //{
        //    gameUI.SetActive(false);
        //}
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}