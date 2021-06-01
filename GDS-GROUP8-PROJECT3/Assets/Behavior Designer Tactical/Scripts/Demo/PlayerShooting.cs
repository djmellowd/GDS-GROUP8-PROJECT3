using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletObject = Instantiate(bullet1);
            bulletObject.transform.position = bullet1.transform.position;
            bulletObject.transform.forward = bullet1.transform.forward;
        }
    }
}
