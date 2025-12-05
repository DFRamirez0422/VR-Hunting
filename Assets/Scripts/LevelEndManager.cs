using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEndManager : MonoBehaviour
{
    [Header("Timer")]
    public float levelTime = 60f;               // Set per level in Inspector
    public Text timerText;                      // Legacy UI Text

    [Header("Losing")]
    public Text loseText;                       // Big UI text for losing
    public string loseMessage = "YOU LOSE";     // Editable message

    [Header("Winning / Next Level")]
    public int requiredScore = 100;              // Score needed to advance
    public string nextSceneName;                // Name of next scene
    public ScoreManager scoreManager;           // Reference to your ScoreManager

    [Header("Player")]
    public PlayerShooter playerShooter;         // Reference to PlayerShooter

    [Header("Countdown")]
    public float countdownDuration = 3f;        // 3, 2, 1
    private bool countdownFinished = false;     // Tracks if countdown is done

    private float currentTime;
    private bool levelEnded = false;

    private void Start()
    {
        if (loseText != null)
            loseText.gameObject.SetActive(true); // Show countdown in this text

        if (playerShooter != null)
            playerShooter.DisableShooting(); // Lock shooting during countdown

        StartCoroutine(RunCountdown());
    }

    private IEnumerator RunCountdown()
    {
        float timer = countdownDuration;

        while (timer > 0f)
        {
            if (loseText != null)
                loseText.text = Mathf.Ceil(timer).ToString(); // 3, 2, 1

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        if (loseText != null)
            loseText.text = "GO!";

        yield return new WaitForSeconds(1f);

        if (loseText != null)
            loseText.gameObject.SetActive(false);

        if (playerShooter != null)
            playerShooter.ResetAmmoAndEnable(); // Unlock shooting

        countdownFinished = true; // Now the main timer can start
        StartLevelTimer();
    }

    private void Update()
    {
        if (levelEnded || !countdownFinished)
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
            playerShooter.DisableShooting();
    }

    public void StartLevelTimer()
    {
        levelEnded = false;
        currentTime = levelTime;
    }
}
