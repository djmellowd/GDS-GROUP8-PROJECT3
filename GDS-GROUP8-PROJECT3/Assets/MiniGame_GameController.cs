using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private float speedPlayer;
    [SerializeField] private LineRenderer[] lineRenderer;

    private int currentCheckPoint = 0;
    Transform currentPoint;
    Transform nextPoint;

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
        Debug.Log("GAME START!");
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
        if (checkPoints.Length <= currentCheckPoint+1)
        {
            currentPoint = checkPoints[currentCheckPoint];
            Debug.Log("YOU WIN!");
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
        lineRenderer[currentCheckPoint-1].positionCount++;
        lineRenderer[currentCheckPoint-1].SetPosition(1, player.transform.position);
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
            if (Mathf.Round(currentPoint.position.x) == Mathf.Round(nextPoint.position.x) && currentPoint.position.y < nextPoint.position.y)
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
            if (Mathf.Round(currentPoint.position.x) == Mathf.Round(nextPoint.position.x) && currentPoint.position.y > nextPoint.position.y)
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
            if (Mathf.Round(currentPoint.position.x) == Mathf.Round(nextPoint.position.x) && currentPoint.position.x < nextPoint.position.x)
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
            if (Mathf.Round(currentPoint.position.y) == Mathf.Round(nextPoint.position.y)&& currentPoint.position.x > nextPoint.position.x)
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
