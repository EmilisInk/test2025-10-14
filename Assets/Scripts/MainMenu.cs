using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    private void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}
