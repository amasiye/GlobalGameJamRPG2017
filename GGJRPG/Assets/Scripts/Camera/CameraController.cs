using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float shakeMagnitude = 0.0025f;
    public float shakeFrequency = 0f;
    public float shakeRate = .01f;
    public float shakeDuration = 0.3f;

    public float shakeMaxDisplacement = 1f;
    public float shakeMinDisplacement = -1f;

    public void ShakeCamera()
    {
        InvokeRepeating("Shake", shakeFrequency, shakeRate);
        Invoke("Stop", shakeDuration);
    } // end Shake()

    void Shake()
    {
        float amount = shakeMagnitude * Random.Range(shakeMinDisplacement, shakeMaxDisplacement);
    } // end Shake()

    void EndShake()
    {

    } // end EndShake()
}
