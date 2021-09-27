using BehaviorDesigner.Runtime.Tactical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerLaser : MonoBehaviour
{
    private const string AudioShootingString = "Shooting";

    public GameObject[] EffectsOnCollision;
    public float DestroyTimeDelay = 1;
    public bool UseWorldSpacePosition;
    public float Offset = 0;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public bool useOnlyRotationOffset = true;
    public bool UseFirePointRotation;
    public bool DestoyMainEffect = true;
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
   

    [SerializeField] PlayerBullet bullet;
    [SerializeField] HudManager hudManager;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public Vector3 starPos;

    private AudioManager audioManager;
    private bool firstInit = true;

    private void Awake()
    {
        hudManager = FindObjectOfType<HudManager>();
        audioManager = FindObjectOfType<AudioManager>();
        part = GetComponent<ParticleSystem>();
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
        //transform.position = Vector3.Lerp(transform.position, direction, bullet.bulletSpeed * Time.deltaTime);
    }


    void OnParticleCollision(GameObject other)
    {
        var enemy = other.gameObject.GetComponent<Health>();
        if (enemy != null && other.gameObject.tag != "Player")
        {
            hudManager.ChangeColorCrosshair();
            enemy.Damage(bullet.damage);
        }

        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        for (int i = 0; i < numCollisionEvents; i++)
        {
            foreach (var effect in EffectsOnCollision)
            {
                var instance = Instantiate(effect, collisionEvents[i].intersection + collisionEvents[i].normal * Offset, new Quaternion()) as GameObject;
                if (!UseWorldSpacePosition) instance.transform.parent = transform;
                if (UseFirePointRotation) { instance.transform.LookAt(transform.position); }
                else if (rotationOffset != Vector3.zero && useOnlyRotationOffset) { instance.transform.rotation = Quaternion.Euler(rotationOffset); }
                else
                {
                    instance.transform.LookAt(collisionEvents[i].intersection + collisionEvents[i].normal);
                    instance.transform.rotation *= Quaternion.Euler(rotationOffset);
                }
                Destroy(instance, DestroyTimeDelay);
            }
        }
        if (DestoyMainEffect == true)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator AutoDestro()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
