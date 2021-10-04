using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentDoor : MonoBehaviour
{
    [SerializeField] private Objects seriaObject;
    [SerializeField] private AutomaticDoor automaticDoor;

    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > seriaObject.rangeToClick)
        {
            return;
        }

        if (Input.GetKeyDown(seriaObject.button))
        {
            if (!automaticDoor.FirstDoor)
            {
                if (automaticDoor.DoorIsOpen)
                {
                    automaticDoor.DoorIsOpen = false;
                }
                else
                {
                    automaticDoor.DoorIsOpen = true;
                }
            }          
        }
    }
}
