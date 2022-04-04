using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause = false;
    public GameObject pauseScreen;

    public void PauseGame()
    {
        isPause = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (isPause)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResumeGame();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        }
    }
    public void ResumeGame()
    {
        isPause = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}
