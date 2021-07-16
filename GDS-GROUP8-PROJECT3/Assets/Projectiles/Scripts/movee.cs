using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movee : MonoBehaviour
{
    [SerializeField] PlayerBullet bullet;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;
    [HideInInspector]public Vector3 direction;

    private float localSpeed;
   

    void OnEnable()
    {
        localSpeed = bullet.bulletSpeed;
        StartCoroutine(AutoDestro());

        var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
        muzzleVFX.transform.forward = gameObject.transform.forward;
        var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
        if (psMuzzle != null)
            Destroy(muzzleVFX, psMuzzle.main.duration);
        else
        {
            var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
            Destroy(muzzleVFX, psChild.main.duration);
        }
    }


    void Update()
    {
        if (localSpeed != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, bullet.bulletSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }
    IEnumerator AutoDestro()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision co)
    {
            localSpeed = 0;
            ContactPoint contact = co.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (hitPrefab != null)
            {
                var hitVFX = Instantiate(hitPrefab, pos, rot);
                var psHit = hitVFX.GetComponent<ParticleSystem>();
                if (psHit != null)
                    Destroy(hitVFX, psHit.main.duration);

                else
                {
                    var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitVFX, psChild.main.duration);
                }
            }

            gameObject.SetActive(false);
        
    }
}