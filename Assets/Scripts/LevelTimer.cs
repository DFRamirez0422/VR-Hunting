using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float levelTime = 60f;   // editable per level
    [SerializeField] private Text timerText;          // legacy UI Text

    private float currentTime;

    private void Start()
    {
        currentTime = levelTime;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f)
                currentTime = 0f;

            UpdateTimerUI();
        }
    }

    private void UpdateTimerUI()
    {
        // Shows 59.8, 59.7, etc.
        timerText.text = currentTime.ToString("0.0");
    }

    // Optional method if you need to restart the timer later
    public void ResetTimer()
    {
        currentTime = levelTime;
    }
}
