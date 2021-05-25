using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainGun : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private PlayerBullet playerBullet;
    [SerializeField] private Camera cam;
    [Header("Ammo")]
    [SerializeField] private Transform parentAmmo;
    [SerializeField] private GameObject ammoPreFab;
    private List<GameObject> _ammoList = new List<GameObject>();
    private Vector3 destination;
    
    void Awake()
    {
        for (int i = 0; i < playerBullet.limitAmmo; i++)
        {
            GameObject ammo = Instantiate(ammoPreFab);
            ammo.transform.parent = parentAmmo;
            _ammoList.Add(ammo);
            ammo.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           
            for (int i = 0; i < _ammoList.Count; i++)
            {
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                destination = ray.GetPoint(1000);
                if (!_ammoList[i].activeInHierarchy)
                {
                    _ammoList[i].transform.position =barrel.transform.position;
                    _ammoList[i].SetActive(true);
                    _ammoList[i].GetComponent<Rigidbody>().velocity =
                        (destination - _ammoList[i].transform.position).normalized* playerBullet.bulletSpeed;
                    return;
                } 
            }
            
        }
    }
}
