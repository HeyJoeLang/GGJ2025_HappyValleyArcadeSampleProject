// PlayerHealthAndScore.cs
using UnityEngine;
using TMPro;

public class PlayerHealthAndScore : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    public TMP_Text healthText;

    [Header("Score Settings")]
    public TMP_Text scoreText;

    private static int currentHealth;
    private static int currentScore;

    public delegate void HealthDecrease();
    public static event HealthDecrease OnHealthDecrease;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public delegate void ScoreIncrease();
    public static event ScoreIncrease OnScoreIncrease;

    void Start()
    {
        // Initialize health and score
        currentHealth = maxHealth;
        currentScore = 0;
        UpdateHealthUI();
        UpdateScoreUI();

        OnHealthDecrease += UpdateHealthUI;
        OnScoreIncrease += UpdateScoreUI;
        OnGameOver += UpdateGameOverUI;
    }

    public static void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthDecrease?.Invoke();

        if (currentHealth <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
    public static int GetHealth()
    {
        return currentHealth;
    }

    public static void AddScore(int score)
    {
        currentScore += score;
        OnScoreIncrease?.Invoke();
    }

    private void UpdateHealthUI()
    {
        healthText.text = string.Format("{0}",currentHealth);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = string.Format("{0}", currentScore);
    }

    private void UpdateGameOverUI()
    {
        Debug.Log("Game Over!");
        // Implement game over logic here (e.g., restart level, show Game Over screen)
    }
}
