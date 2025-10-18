using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;
    public int currentScore = 0;
    public int currentHealth = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI health;
    public AudioSource gameOverSound;
    public GameObject gameOverUI;
    public TextMeshProUGUI gameoverorwin;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI collectedJewelsText;
    private float elapsedTime = 0f;
    private bool isRunning = true;
    public Button quitButton;
    public Button restartButton;
    public Button mainMenuButton;

    private void Start()
    {
        gameOverUI.SetActive(false);

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(LoadMainMenu);
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);
            timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }


    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float getTime()
    {
        return elapsedTime;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateScoreUI();
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();

        if(currentScore >= 19)
        {
            GameOver();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }

    private void UpdateHealthUI()
    {
        if (health != null)
        {
            health.text = currentHealth.ToString();
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        UpdateHealthUI();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        currentScore = 0;
        currentHealth = 3;
        elapsedTime = 0f;
        isRunning = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void RestartGame()
    {
        ResetGame();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private void GameOver()
    {
        StopTimer();
        Debug.Log("Game Over!");
        gameOverSound.Play();
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        if (currentScore >= 19)
        {
            gameoverorwin.text = "You Win!";
            gameoverorwin.color = Color.green;
        }
        else
        {
            gameoverorwin.text = "Game Over!";
        }
        healthText.text = "Health: " + currentHealth.ToString();
        collectedJewelsText.text = "Collected Jewels: " + currentScore.ToString();
    }


}

