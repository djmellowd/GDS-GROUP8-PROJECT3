using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public void MakeSingleton()
    {
        DontDestroyOnLoad(gameObject);
    }
}
