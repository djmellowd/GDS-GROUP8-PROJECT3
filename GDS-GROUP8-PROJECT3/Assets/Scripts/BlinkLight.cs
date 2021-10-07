using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float timeBetweenBlink;

    private float awakeIntensity = 0;
    private void Awake()
    {
        awakeIntensity = light.intensity;
        Blink();
    }

    private void Blink()
    {
        InvokeRepeating("LightOff", timeBetweenBlink, timeBetweenBlink);
        InvokeRepeating("LightOn", timeBetweenBlink + 0.1f, timeBetweenBlink + 0.1f);
    }

    private void LightOff()
    {
        light.intensity = 0;
    }

    private void LightOn()
    {
        light.intensity = awakeIntensity;
    }
}
