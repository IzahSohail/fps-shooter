using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 60f;
    private float currentHealth;

    public string objectType = "Enemy"; // "Player" or "Enemy"
    public GameObject gameOverCanvas;   // Assign this in the Inspector for Player only

    void Start()
    {
        currentHealth = maxHealth;

        // Ensure the game over screen starts hidden
        if (objectType == "Player" && gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"{objectType} took {amount} damage. Health now: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (objectType == "Player")
        {
            Debug.Log("Player died!");

            if (gameOverCanvas != null)
            {
                Debug.Log("Enabling Game Over screen via assigned reference");
                gameOverCanvas.SetActive(true);
                Time.timeScale = 100f; // Optional
            }
            else
            {
                Debug.LogWarning("GameOverCanvas reference not assigned!");
            }
        }
        else if (objectType == "Enemy")
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        }
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
}
