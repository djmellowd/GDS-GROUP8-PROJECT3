using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField]private Renderer mRenderer;
    [SerializeField]private bool onHit;
    [SerializeField]private int hit = 3;
    [SerializeField]private bool onClick;
    public bool openDoor;

    private int _hitTimes;

    private void OnMouseOver()
    {
        if (onClick)
        {
            mRenderer.material.color = Color.gray;
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 newPos =  new Vector3(transform.position.x - 0.2f,transform.position.y,transform.position.z);
                gameObject.transform.Translate(newPos);
                openDoor = true;
            }
        }
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if (onHit)
        {
            if (other.gameObject.tag == "Bullet")
            {
                Debug.Log(1);
                _hitTimes += 1;
                if (_hitTimes== hit)
                {
                    openDoor = true;
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (onClick)
        {
            mRenderer.material.color = Color.black;
        }
        
    }
}
