using System.Collections;
using UnityEngine;

public class Starship : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveDuration = 3f;
    public float tiltAmplitude = 10f; // amplitud de inclinaci�n (antes xTiltAngle)
    public float tiltFrequency = 2f; // qu� tan r�pido oscila
    public float timeCooldown = 10f;

    private bool movingToB = true;

    private void Start()
    {
        StartCoroutine(MoveLoop());
    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            Transform from = movingToB ? pointA : pointB;
            Transform to = movingToB ? pointB : pointA;

            float elapsed = 0f;
            while (elapsed < moveDuration)
            {
                float t = elapsed / moveDuration;

                // Movimiento lineal
                transform.position = Vector3.Lerp(from.position, to.position, t);

                // Direcci�n hacia el objetivo
                Vector3 direction = (to.position - from.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);

                // Oscilaci�n de inclinaci�n con Mathf.Sin
                float oscillatingTilt = Mathf.Sin(elapsed * tiltFrequency * Mathf.PI * 2f) * tiltAmplitude;
                Quaternion tiltRotation = lookRotation * Quaternion.Euler(oscillatingTilt, 0, 0);

                // Aplicar rotaci�n suavemente
                transform.rotation = Quaternion.Slerp(transform.rotation, tiltRotation, Time.deltaTime * 5f);

                elapsed += Time.deltaTime;
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = to.position;

            yield return new WaitForSeconds(timeCooldown);

            movingToB = !movingToB;
        }
    }
}
