using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private Objects seriaObject;
    private bool isActive = false;

    public bool IsActive => isActive;

    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > seriaObject.rangeToClick)
        {
            return;
        }

        if (Input.GetKeyDown(seriaObject.button))
        {
            isActive = true;
        }
    }
}
