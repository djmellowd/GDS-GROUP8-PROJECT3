using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControler : MonoBehaviour
{
    [SerializeField] private float timeToDestroy=0.2f;
     public Transform startPos;
    private void OnEnable()
    {
        StartCoroutine(DestoryThis());
    }
    private void Update()
    {
        if (startPos!=null)
        {
            transform.position = startPos.position;
        }
       
    }
    IEnumerator DestoryThis()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
