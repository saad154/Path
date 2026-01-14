using System.Collections;
using UnityEngine;

public class DisapperaingPlatform : MonoBehaviour
{
    public float delay = 3f;

    private Renderer rend;
    private Collider col;
    private bool isVisible = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && isVisible)
        {
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        isVisible = false;

        yield return new WaitForSeconds(delay);

        rend.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(delay);

        rend.enabled = true;
        col.enabled = true;

        isVisible = true;
    }
}
