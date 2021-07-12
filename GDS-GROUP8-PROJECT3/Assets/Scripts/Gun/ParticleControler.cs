using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{
    [SerializeField] private float timeToDestroy=0.2f;
    [HideInInspector] public GameObject startPos;
    private void OnEnable()
    {
        StartCoroutine(DestoryThis());
    }
    private void Update()
    {
        transform.position = startPos.transform.position;
    }
    IEnumerator DestoryThis()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
