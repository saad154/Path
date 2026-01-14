using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform cam;
    public float parallaxStrength;

    private Vector3 lastCamPos;

    void Start()
    {
        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastCamPos;
        transform.position += new Vector3(delta.x * parallaxStrength, delta.y * parallaxStrength, 0f);
        lastCamPos = cam.position;
    }
}
