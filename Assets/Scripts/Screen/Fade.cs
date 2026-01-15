using UnityEngine;

public class Fade : MonoBehaviour
{
    public ScreenFade screenFade;
    public TimeManager time;
    public Canvas canva;
    public Dirty_Meter dirty;
    public GameObject dirtMeterObject;

    bool triggered;

    private void Start()
    {
        canva.planeDistance = 13.51f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        if (dirty.currentDirtvalue > 0f)
        {
            Debug.Log("Go get yourself cleaned");
            return;
        }

        triggered = true;
        screenFade.FadeInAndPause();
        time.timerIsRunning = false;
        canva.planeDistance = 9f;

        if (dirtMeterObject)
            dirtMeterObject.SetActive(false);
    }
}
