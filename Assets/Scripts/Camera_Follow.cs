using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float deadZoneX = 0.5f;
    public float fixedY = 2f;
    public float fixedZ = -10f;

    public float minX = 0f;
    public float maxX = 13.88f;

    void LateUpdate()
    {
        if (!target) return;

        float cameraX = transform.position.x;
        float targetX = target.position.x;

        if (Mathf.Abs(targetX - cameraX) > deadZoneX)
        {
            cameraX = Mathf.Lerp(
                cameraX,
                targetX,
                smoothSpeed * Time.deltaTime
            );
        }

        cameraX = Mathf.Clamp(cameraX, minX, maxX);

        transform.position = new Vector3(cameraX, fixedY, fixedZ);
    }
}
