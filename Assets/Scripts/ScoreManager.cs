using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;
    public int currentScore = 0;
    public int currentHealth = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI health;
    public AudioSource gameOverSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        UpdateScoreUI();
        UpdateHealthUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
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

    private void GameOver()
    {
        // Implement game over logic here
        Debug.Log("Game Over!");
        gameOverSound.Play();
        Time.timeScale = 0f;
    }


}

