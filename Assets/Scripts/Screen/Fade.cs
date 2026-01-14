using UnityEngine;

public class Fade : MonoBehaviour
{
    public ScreenFade screenFade;
    public TimeManager time;

    public Canvas canva;

    private void Start()
    {
        canva.planeDistance = 13.51f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            screenFade.FadeInAndPause();
            time.timerIsRunning = false;
            canva.planeDistance = 9f;
        }
    }
}
