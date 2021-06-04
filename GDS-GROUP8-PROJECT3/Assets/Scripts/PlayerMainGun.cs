using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainGun : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private PlayerBullet playerBullet;
    [SerializeField] private Camera cam;
    [SerializeField] private Renderer lufa;
    [Header("Ammo")]
    [SerializeField] private Transform parentAmmo;
    [SerializeField] private GameObject ammoPreFab;
    private List<GameObject> _ammoList = new List<GameObject>();
    private Vector3 _destination;
    private int _resetGun;
    
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
        if (Input.GetMouseButtonDown(0))
        {
            Overheating();
        }
    }
    private void Overheating()
    {
        if (_resetGun <playerBullet.limitAmmo)
        {
            StopAllCoroutines();
            _resetGun += 1;
            Shooting();
            StartCoroutine(TimeBetweenShoots()); 
        }
        else
        {
            lufa.material.color = Color.red;
                Debug.Log("Bron przegrzana");
        }
    }

    IEnumerator TimeBetweenShoots()
    {
        yield return new WaitForSeconds(playerBullet.overheatingTime);
        lufa.material.color = Color.black;
        _resetGun = 0;
    }
    private void Shooting()
    {
        for (int i = 0; i < _ammoList.Count; i++)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _destination = hit.point;
            }
            else
            {
                _destination = ray.GetPoint(1000);
            }
            if (!_ammoList[i].activeInHierarchy)
            {
                _ammoList[i].transform.position =barrel.transform.position;
                _ammoList[i].SetActive(true);
                _ammoList[i].GetComponent<Rigidbody>().velocity =
                    (_destination - _ammoList[i].transform.position).normalized* playerBullet.bulletSpeed;
                return;
            } 
        }
    }
}
