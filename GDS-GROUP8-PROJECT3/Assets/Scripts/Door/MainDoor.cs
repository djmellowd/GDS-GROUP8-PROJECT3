using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour
{
    [SerializeField] private Transform leftPart;
    [SerializeField] private Transform rightPart;
    [SerializeField] private float deviation = 0;
    [SerializeField] private int speed;

    [Header("Otwieranie")] [SerializeField]
    private DoorButton button1;

    [SerializeField] private DoorButton button2;
    [SerializeField] private DoorButton button3;

    private bool _closeDoor;
    private Vector3 _leftDir;
    private Vector3 _rightDir;

    private void Awake()
    {
        _leftDir = new Vector3(leftPart.position.x , leftPart.position.y, leftPart.position.z+ deviation);
        _rightDir = new Vector3(rightPart.position.x, rightPart.position.y , rightPart.position.z- deviation);
    }
    private void Update()
    {
        if (button1.openDoor && button2.openDoor && button3.openDoor)
        {
            OpenDoor();
        }
    }
    private void OpenDoor()
    {
        leftPart.position = Vector3.MoveTowards(leftPart.position, _leftDir, speed * Time.deltaTime);
        rightPart.position = Vector3.MoveTowards(rightPart.position, _rightDir, speed * Time.deltaTime);
    }
}
