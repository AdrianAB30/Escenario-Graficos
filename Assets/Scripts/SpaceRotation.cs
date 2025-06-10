using UnityEngine;

public class SpaceRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;

    void Update()
    {
        transform.Rotate(-rotationSpeed * Time.deltaTime, -rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}

