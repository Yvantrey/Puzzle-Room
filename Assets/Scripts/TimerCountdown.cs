using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject lostPanel;
    public float timeRemaining = 180f; // 3 minutes = 180 seconds
    private bool timerRunning = true;

    void Update()
    {
        if (!timerRunning)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            UpdateTimerDisplay(timeRemaining);
            if (lostPanel != null)
                lostPanel.SetActive(true);
            Debug.Log("Time's up!");
        }
    }

    void UpdateTimerDisplay(float time)
    {
        if (timerText == null)
            return;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
