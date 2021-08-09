using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public Camera[] cameras;

    [SerializeField] GameObject GO;
    [SerializeField] GameObject GO2;
    [SerializeField] GameObject GO3;
    [SerializeField] GameObject GO4;
    [SerializeField] GameObject GO5;
    [SerializeField] GameObject GO6;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GO.SetActive(false);
        GO2.SetActive(false);
        GO3.SetActive(false);
        GO4.SetActive(false);
        GO5.SetActive(true);
        GO6.SetActive(true);
        cameras[0].gameObject.SetActive(true);
    }
}
