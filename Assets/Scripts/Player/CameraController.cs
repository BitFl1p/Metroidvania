using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera shaker;
    public IEnumerator Shake(float time, float magnitude)
    {
        var perlin = shaker.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        while (time > 0)
        {
            time -= Time.unscaledDeltaTime;
            perlin.m_AmplitudeGain = magnitude;
            //transform.position = pos + new Vector2(Random.Range(-magnitude, magnitude), Random.Range(-magnitude, magnitude));
            yield return null;
        }
        perlin.m_AmplitudeGain = 0;
    }
        
}
