using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class HadithCollector : MonoBehaviour
{
    public Image hadithDisplay; // The UI Image in canvas that shows Hadith
    private bool canHide;

    public Canvas canva;

    private void Start()
    {
        hadithDisplay.gameObject.SetActive(false);
        canHide = false;
        canva.planeDistance = 13.51f;
    }

    private void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.E))
        {
            hadithDisplay.gameObject.SetActive(false);
            canva.planeDistance = 13.51f;
            canHide = false;
            Time.timeScale = 1f;
            GameManager.instance.isPaused = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hadith hadith = other.GetComponent<Hadith>();
        if (hadith != null)
        {
            hadithDisplay.sprite = hadith.hadithImage; // Set the image
            hadithDisplay.gameObject.SetActive(true);
            canHide = true;
            Time.timeScale = 0f;
            GameManager.instance.isPaused = true;
            Destroy(other.gameObject); // Remove collected Hadith
            canva.planeDistance = 9f;
        }
    }
}
