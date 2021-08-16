using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private const string AmbientAudio = "Ambient";
    private const string MusicLvlAudio = "MusicLvl";

    [SerializeField] private Transform player;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play(AmbientAudio);
        audioManager.Play(MusicLvlAudio);
    }

    void Update()
    {
        transform.position = player.transform.position;
    }

}
