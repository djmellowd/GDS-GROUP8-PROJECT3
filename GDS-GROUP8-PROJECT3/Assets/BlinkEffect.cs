using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{

    [SerializeField] private Light light;
    [SerializeField] private ScritableOneValue blinkSpeedValue;
    [SerializeField] private ScritableOneValue timeOfValue;

    private float blinkValue;

    private float noramlIntensity;
    private void Awake()
    {
        blinkValue = blinkSpeedValue.Value;
        noramlIntensity = light.intensity;
    }

    void Start()
    {
        InvokeRepeating("Blink", 0, blinkValue);
    }

   
    private void Blink()
    {
        StartCoroutine(BlinkStart());
    }
    IEnumerator BlinkStart()
    {
        light.intensity = 0;
        yield return new WaitForSeconds(timeOfValue.Value);
        light.intensity = noramlIntensity;
    }
}
