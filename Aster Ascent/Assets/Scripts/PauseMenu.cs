using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject UIDocument;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
            pauseMenuUI.SetActive(false);
            UIDocument.SetActive(true);
            Time.timeScale = 1f;
            GameIsPaused = false;
    }

    void Pause()
    {
            pauseMenuUI.SetActive(true);
            UIDocument.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT DEEZ NUTS");
        Application.Quit();
    }
}
