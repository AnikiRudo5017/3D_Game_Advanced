using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineFollow cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    void Start()
    {
        cinemachineCamera = GetComponent<CinemachineFollow>();
        noise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(Shake(10, 1));
    }

    public void ShakeCamera(float intensity, float duration)
    {
        StartCoroutine(Shake(intensity, duration));
    }

    IEnumerator Shake(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        yield return new WaitForSeconds(duration);
        noise.AmplitudeGain = 0f;
    }
}