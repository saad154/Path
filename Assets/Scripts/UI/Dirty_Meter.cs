using UnityEngine;
using UnityEngine.UI;

public class Dirty_Meter : MonoBehaviour
{
    public Slider dirtyMeter;

    public float maxDirtValue = 1f;
    public float currentDirtvalue;

    private void Start()
    {
        currentDirtvalue = 0;
        dirtyMeter.maxValue = maxDirtValue;
        dirtyMeter.minValue = currentDirtvalue;
        dirtyMeter.value = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Dirt")) return;

        currentDirtvalue = Mathf.Clamp(currentDirtvalue + 0.2f, 0, maxDirtValue);

        dirtyMeter.value = currentDirtvalue;
    }
}
