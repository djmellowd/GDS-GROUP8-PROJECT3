using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton _Singleton;
    void Awake()
    {
        if (_Singleton == null)
            _Singleton = this;
        else
        {
            Destroy(gameObject);
            return;
        }

       DontDestroyOnLoad(gameObject);
    }
}
