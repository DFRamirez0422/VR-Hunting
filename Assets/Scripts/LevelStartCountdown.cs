using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelStartCountdown : MonoBehaviour
{
    public Text countdownText;        // Assign your existing LoseText UI here
    public float countdownDuration = 3f; // How many seconds to count down
    public PlayerShooter playerShooter; // Assign PlayerShooter to enable shooting after countdown
    public LevelEndManager levelEndManager; // Optional, to start level timer

    private void Start()
    {
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true);
        }

        if (playerShooter != null)
            playerShooter.DisableShooting(); // Lock shooting during countdown

        StartCoroutine(RunCountdown());
    }

    private IEnumerator RunCountdown()
    {
        float timer = countdownDuration;

        while (timer > 0f)
        {
            if (countdownText != null)
                countdownText.text = Mathf.Ceil(timer).ToString(); // 3,2,1

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        if (countdownText != null)
            countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        if (countdownText != null)
            countdownText.gameObject.SetActive(false);

        // Unlock player shooting
        if (playerShooter != null)
        {
            playerShooter.ResetAmmoAndEnable();
        }

        // Start the level timer
        if (levelEndManager != null)
        {
            levelEndManager.StartLevelTimer();
        }
    }
}
