using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{
    [SerializeField] private float timeToDestroy=0.2f;
    private void OnEnable()
    {
        StartCoroutine(DestoryThis());
    }

    IEnumerator DestoryThis()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
