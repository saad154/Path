using UnityEngine;
using UnityEngine.UI;

public class Dirty_Meter : MonoBehaviour
{
    public float maximumDirty = 1f;
    public float startDirtyMeter;
    public float currentDirtyMeterValue;
    public Slider dirtyMeter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startDirtyMeter = 0f;
        dirtyMeter = GetComponent<Slider>();
        dirtyMeter.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dirt" && currentDirtyMeterValue != maximumDirty)
        {
            currentDirtyMeterValue += 0.2f;
            dirtyMeter.value = currentDirtyMeterValue;
        }
    }
}
