/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/

/*using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameUI; // Opcional, si tienes una UI de juego que quieres desactivar al pausar

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

    public void Resume()
    {
        menu.SetActive(false);
        if (gameUI != null)
        {
            gameUI.SetActive(true);
        }
        Time.timeScale = 1f; 
        isPaused = false;
    }

    void Pause()
    {
        
        menu.SetActive(true);
        if (gameUI != null)
        {
            gameUI.SetActive(false);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}*/