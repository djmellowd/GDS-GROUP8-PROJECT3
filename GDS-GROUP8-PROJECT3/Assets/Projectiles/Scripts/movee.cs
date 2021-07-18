using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tactical;

public class movee : MonoBehaviour
{
    private const string AudioShootingString = "Shooting";

    [SerializeField] PlayerBullet bullet;
    [SerializeField] GameObject hitPrefab;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public Vector3 starPos;

    private AudioManager audioManager;
    private bool firstInit = true;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnEnable()
    {
        if (firstInit)
        {
            firstInit = false;
        }
        else
        {
            audioManager.Play(AudioShootingString);
        }


        StartCoroutine(AutoDestro());
    }
    void Update()
    {
       transform.position = Vector3.Lerp(transform.position, direction, bullet.bulletSpeed * Time.deltaTime);
    }

    IEnumerator AutoDestro()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision other)
    {
        var enemy = other.gameObject.GetComponent<Health>();
        if (enemy != null && other.gameObject.tag != "Player")
        {
            enemy.Damage(bullet.damage);
        }
        else
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            var hitVFX = Instantiate(hitPrefab, pos, rot);
            var psHit = hitVFX.GetComponent<ParticleSystem>();
            if (psHit != null)
            {
                Destroy(hitVFX, psHit.main.duration);
            }
            else
            {
                var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(hitVFX, psChild.main.duration);
            }
        }
        gameObject.SetActive(false);      
    }
}