﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : Singleton
{
    [Header("Player")]
    public GameObject Player;
    public GameObject HeadPlayer;
    public GameObject PlayerGun;

    public Camera MainCamera;  
    public Canvas MainCanvas;
    public List<Canvas> MiniGameCanvas;
    public List<MiniGame_GameController> MiniGameControler;

}
