using UnityEngine;

public class FireLightFlicker : MonoBehaviour
{
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    [SerializeField] private float minIntensity = 0.8f;
    [SerializeField] private float maxIntensity = 1.2f;
    [SerializeField] private float flickerSpeed = 5f;

    private float targetIntensity1;
    private float targetIntensity2;

    void Start()
    {
        targetIntensity1 = Random.Range(minIntensity, maxIntensity * 10);
        targetIntensity2 = Random.Range(minIntensity, maxIntensity * 10);
    }

    void Update()
    {
        if (Random.value < 0.1f)
        {
            targetIntensity1 = Random.Range(minIntensity, maxIntensity * 10);
        }
        if (Random.value < 0.1f)
        {
            targetIntensity2 = Random.Range(minIntensity, maxIntensity * 10);
        }

        light1.intensity = Mathf.Lerp(light1.intensity, targetIntensity1, flickerSpeed * Time.deltaTime);
        light2.intensity = Mathf.Lerp(light2.intensity, targetIntensity2, flickerSpeed * Time.deltaTime);
    }
}
