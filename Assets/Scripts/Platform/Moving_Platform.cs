using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    private float t = 0f;
    private bool forward = true;

    void Start()
    {
        transform.position = pointA.position;
    }

    void Update()
    {
        if (forward)
        {
            t += Time.deltaTime * moveSpeed;
            if (t >= 1f)
            {
                t = 1f;
                forward = false;
            }
        }
        else
        {
            t -= Time.deltaTime * moveSpeed;
            if (t <= 0f)
            {
                t = 0f;
                forward = true;
            }
        }

        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
