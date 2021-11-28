using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCode : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //sound
        FindObjectOfType<audioManager>().Play("clickingSmall");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //sound
        FindObjectOfType<audioManager>().Play("clickingBig");

    }

    public void MainMenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        //sound
        FindObjectOfType<audioManager>().Play("clickingBig");

    }

}
