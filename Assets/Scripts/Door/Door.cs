using UnityEngine;

public class Door : MonoBehaviour
{
    public KeyCollector key;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpener()
    {
        if (key.topDoorKey == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DoorOpener();
    }
}
