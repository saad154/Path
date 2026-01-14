using UnityEngine;

public class CoinSpinning : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 180f;
    float yRotation;

    void Update()
    {
        yRotation += spinningSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(90f, yRotation, 0f);
    }
}
