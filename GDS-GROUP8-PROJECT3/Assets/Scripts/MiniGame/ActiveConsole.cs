using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveConsole : MonoBehaviour
{
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private Objects seriaObject;
    [SerializeField] private int miniGameLvl;

    [SerializeField] private float speed;
    private GameContoller gameContoller;


    private Camera playerCam;
    private Transform startPosCamera = null;
    private bool isOnConsole=false;

    private void Start()
    {    
        gameContoller = FindObjectOfType<GameContoller>();
        playerCam = gameContoller.MainCamera;
    }
    private void OnMouseOver()
    {
        if (isOnConsole)
        {
            return;
        }
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > seriaObject.rangeToClick)
        {
            return;                    
        }
        
        if (Input.GetKeyDown(seriaObject.button))
        {
            startPosCamera = playerCam.transform;
            DisActiveGame();
        }
    }

    private void DisActiveGame()
    {
        isOnConsole = true;

        gameContoller.MainCanvas.gameObject.SetActive(false);
        gameContoller.Player.SetActive(false);
        gameContoller.PlayerGun.SetActive(false);
    }
    private void ActiveGame()
    {
        isOnConsole = false;
        gameContoller.MiniGameCanvas[miniGameLvl].gameObject.SetActive(false);
        gameContoller.MainCanvas.gameObject.SetActive(true);
        gameContoller.Player.SetActive(true);
        gameContoller.PlayerGun.SetActive(true);

        playerCam.transform.parent = gameContoller.HeadPlayer.transform;
        playerCam.transform.position = gameContoller.HeadPlayer.transform.position;
        playerCam.transform.rotation = gameContoller.HeadPlayer.transform.rotation;
    }

    private void Update()
    {
        if (gameContoller.MiniGameControler[miniGameLvl].UnlockWin)
        {
            ActiveGame();
            return;
        }
        if (isOnConsole && playerCam.transform.position != cameraPoint.position && playerCam.transform.rotation != cameraPoint.rotation)
        {
            playerCam.transform.parent = cameraPoint;
            playerCam.transform.position = Vector3.Lerp(playerCam.transform.position, cameraPoint.position, speed * Time.deltaTime);
            playerCam.transform.rotation = Quaternion.Lerp(playerCam.transform.rotation, cameraPoint.rotation, speed * Time.deltaTime);
        }
        else if (isOnConsole)
        {
            gameContoller.MiniGameCanvas[miniGameLvl].gameObject.SetActive(true);
            if (Input.GetKeyDown(seriaObject.button))
            {
                ActiveGame();
            }
        }
    }
}
