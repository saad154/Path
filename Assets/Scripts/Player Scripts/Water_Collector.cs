using UnityEngine;

public class Water_Collector : MonoBehaviour
{
    public Dirty_Meter dirt;
    float waterCollectedValue = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Clean")) return;

        if (dirt.currentDirtvalue <= 0f) return;

        dirt.currentDirtvalue = Mathf.Clamp(
            dirt.currentDirtvalue - waterCollectedValue,
            0f,
            dirt.maxDirtValue
        );

        dirt.dirtyMeter.value = dirt.currentDirtvalue;
    }
}
