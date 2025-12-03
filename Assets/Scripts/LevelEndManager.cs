using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    [Header("Timer")]
    public float levelTime = 60f;               // Set per level in Inspector
    public Text timerText;                      // Legacy UI Text

    [Header("Losing")]
    public Text loseText;                       // Big UI text for losing
    public string loseMessage = "YOU LOSE";     // Editable message

    [Header("Winning / Next Level")]
    public int requiredScore = 10;              // Score needed to advance
    public string nextSceneName;                // Name of next scene
    public ScoreManager scoreManager;           // Reference to your ScoreManager

    [Header("Player")]
    public PlayerShooter playerShooter;         // Reference to PlayerShooter

    private float currentTime;
    private bool levelEnded = false;

    private void Start()
    {
        currentTime = levelTime;

        if (loseText != null)
            loseText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (levelEnded)
            return;

        HandleTimer();
        CheckScoreForWin();
    }

    private void HandleTimer()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f)
                currentTime = 0f;

            if (timerText != null)
                timerText.text = "Time left: " + currentTime.ToString("0.0");
        }
        else
        {
            TriggerLose();
        }
    }

    private void CheckScoreForWin()
    {
        if (scoreManager == null)
            return;

        if (scoreManager.GetScore() >= requiredScore)
        {
            levelEnded = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void TriggerLose()
    {
        levelEnded = true;

        if (loseText != null)
        {
            loseText.text = loseMessage;
            loseText.gameObject.SetActive(true);
        }

        if (playerShooter != null)
        {
            playerShooter.DisableShooting();
        }
    }
}
