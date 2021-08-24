using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GameController : MonoBehaviour
{
    public bool UnlockWin => unlockWin;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private float speedPlayer;
    [SerializeField] private LineRenderer[] lineRenderer;

    private int currentCheckPoint = 0;
    private Transform currentPoint;
    private Transform nextPoint;

    private bool unlockWin = false;

    private void Awake()
    {
        currentPoint = checkPoints[currentCheckPoint];
        nextPoint = checkPoints[currentCheckPoint + 1];
        StartGame();
    }

    void Update()
    {
        CheckNextPointLocation();
    }

    private void StartGame()
    {
        currentCheckPoint = 0;
        RefreshPoints();
        player.transform.position = checkPoints[0].position;

        for (int i = 0; i < checkPoints.Length; i++)
        {
            lineRenderer[i].positionCount = 1;
            lineRenderer[i].SetPosition(0, checkPoints[i].position);
        }

    }

    private void GoToNextPoint()
    {

        currentCheckPoint++;

        player.transform.position = nextPoint.position;
        SetUpLine();
        if (checkPoints.Length <= currentCheckPoint + 1)
        {
            currentPoint = checkPoints[currentCheckPoint];
            unlockWin = true;
        }
        else
        {
            RefreshPoints();
        }
    }

    private void RefreshPoints()
    {
        currentPoint = checkPoints[currentCheckPoint];
        nextPoint = checkPoints[currentCheckPoint + 1];
    }

    public void SetUpLine()
    {
        lineRenderer[currentCheckPoint - 1].positionCount++;
        lineRenderer[currentCheckPoint - 1].SetPosition(1, player.transform.position);
    }

    private void CheckNextPointLocation()
    {

        /*      if (player.transform.position != currentPoint.position)
               {
                   player.transform.position = Vector3.Lerp(player.transform.position, currentPoint.position, speedPlayer * Time.deltaTime);
                   return;
               }
        */

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Mathf.Round(currentPoint.localPosition.x) == Mathf.Round(nextPoint.localPosition.x) && currentPoint.localPosition.y < nextPoint.localPosition.y)
            {
                GoToNextPoint();
            }
            else
            {
                StartGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPoint.localPosition.x == nextPoint.localPosition.x && currentPoint.localPosition.y > nextPoint.localPosition.y)
            {
                GoToNextPoint();
            }
            else
            {
                StartGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPoint.localPosition.y == nextPoint.localPosition.y && currentPoint.localPosition.x > nextPoint.localPosition.x)
            {
                GoToNextPoint();
            }
            else
            {
                StartGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPoint.localPosition.y == nextPoint.localPosition.y && currentPoint.localPosition.x < nextPoint.localPosition.x)
            {
                GoToNextPoint();
            }
            else
            {
                StartGame();
            }
        }
    }
}
