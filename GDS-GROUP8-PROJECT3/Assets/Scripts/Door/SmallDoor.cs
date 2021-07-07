using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDoor : MonoBehaviour
{
    [SerializeField] private Transform part;
    [SerializeField] private bool onTrigger;
    [SerializeField] private int speed;
    [SerializeField] private float deviation=0;
    private bool _closeDoor;
    private Vector3 _partDir;
    private Vector3 _partStart;
    
    
    private void Awake()
    {
        _partStart = part.position;

        _partDir = new Vector3(part.position.x,part.position.y+deviation,part.position.z);
    }
    private void Update()
    {
        if (_closeDoor)
        {
            CloseDoor();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (onTrigger)
        {
            if (other.tag == "Player")
            {
                _closeDoor = false;
                OpenDoor();
            }  
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (onTrigger)
        {
            if (other.tag == "Player")
            {
                _closeDoor = true;
            } 
        }
    }
    private void OpenDoor()
    {
        part.position = Vector3.MoveTowards( part.position,_partDir,speed*Time.deltaTime);

    }

    private void CloseDoor()
    {
        Vector3 currentPosLeft = part.position;

        part.position = Vector3.MoveTowards(currentPosLeft,_partStart,speed*Time.deltaTime);

    }

}
