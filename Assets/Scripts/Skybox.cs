using UnityEngine;

public class Skybox : MonoBehaviour
{
    [SerializeField] public float rotationSpeed;
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }
}
