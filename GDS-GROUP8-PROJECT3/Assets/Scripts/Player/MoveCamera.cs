using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private const string AmbientAudio = "Ambient";

    [SerializeField] private Transform player;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play(AmbientAudio);
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
}
