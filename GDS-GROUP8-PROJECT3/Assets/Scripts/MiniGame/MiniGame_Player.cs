using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MiniGame_Player : MonoBehaviour
{
    public float speed = 10.0f;
    void Start()
    {
        
    }


    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(rotation, translation, 0 );
    }
}
