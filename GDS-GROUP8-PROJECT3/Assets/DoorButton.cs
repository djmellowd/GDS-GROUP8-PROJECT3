using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]private Renderer mRenderer;
    public bool openDoor;
    
   

    private void OnMouseOver()
    {
        Debug.Log(1);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 newPos =  new Vector3(transform.position.x - 0.2f,transform.position.y,transform.position.z);
            gameObject.transform.Translate(newPos);
            openDoor = true;
        }
    }

    private void OnMouseExit()
    {
        Debug.Log(0);
    }
}
