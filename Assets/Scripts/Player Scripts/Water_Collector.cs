using UnityEngine;

public class Water_Collector : MonoBehaviour
{
    Dirty_Meter dirt;

    float waterCollectedValue = 0.2f;

    private void Start()
    {
        dirt = GetComponent<Dirty_Meter>();
    }

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
        Destroy(other.gameObject);
    }
}
