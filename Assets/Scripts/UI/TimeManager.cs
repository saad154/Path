using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class TimeManager : MonoBehaviour 
{
    public float timeRemaining = 60f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI countdownText;

    public GameObject gameOver;
    public Canvas canva;

    void Start()
    {
        timerIsRunning = true;
        UpdateDisplay(timeRemaining);
        gameOver.SetActive(false);
        canva.planeDistance = 13.51f;
        GameManager.instance.overState = false;
    }

    void Update()
    {
        if (!timerIsRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateDisplay(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerIsRunning = false;
            UpdateDisplay(timeRemaining);
            gameOver.SetActive(true);
            canva.planeDistance = 8f;
            Time.timeScale = 0;
            GameManager.instance.overState = true;
        }
    }

    void UpdateDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        countdownText.text = $"Jamaat In : {minutes:00}:{seconds:00}";
    }
}
