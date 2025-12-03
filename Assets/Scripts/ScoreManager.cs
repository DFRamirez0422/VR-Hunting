using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    // Call this when an enemy is destroyed
    public void AddScore(int amount = 1)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = "Current Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
