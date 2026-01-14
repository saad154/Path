using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public bool topDoorKey = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TopDoorKey")
        {
            Destroy(other.gameObject);
            topDoorKey = true;
        }
    }
}
