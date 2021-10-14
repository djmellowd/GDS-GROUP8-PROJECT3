using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private List<EndGameButton> endGameButtons;
    [SerializeField] private List<MiniGun> miniGuns;
    [SerializeField] private GameObject hologram;
    [SerializeField] private AudioSource audioSource;
    [SerializeField][TextArea(2,6)] private string hologramText;
    [SerializeField] private float hologramTime;
    private TextBoxManager textBoxManager;
    private HudManager hudManager;
    private GameContoller gameContoller;

    private bool firstAwake=true;
    private GameObject player;
    private void Start()
    {
        hudManager = FindObjectOfType<HudManager>();
        textBoxManager = FindObjectOfType<TextBoxManager>();

        gameContoller = FindObjectOfType<GameContoller>();
        player = gameContoller.Player;
    }
    private void Update()
    {
        if (firstAwake)
        {
            if (IsAllMissionComplete())
            {
                hologram.SetActive(true);
                textBoxManager.ActiveBox(hologramText, hologramTime);

                firstAwake = false;
                audioSource.Play();
                StartCoroutine(StartAttackPlayer(audioSource.clip.length));
            }
        }
        if (miniGuns[0].IsDestory && miniGuns[1].IsDestory)
        {
            hudManager.GoToEnd();
        }
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.x = hologram.transform.localPosition.x;
        var rotation = Quaternion.LookRotation(lookPos);
        hologram.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 650);

    }

    private IEnumerator StartAttackPlayer(float time)
    {
        yield return new WaitForSeconds(time);
        StartAttack();
    }

    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < endGameButtons.Count; ++i)
        {
            if (endGameButtons[i].IsActive == false)
            {
                return false;
            }
        }

        return true;
    }

    private void StartAttack()
    {
        textBoxManager.EndGameBox();
        foreach (var item in miniGuns)
        {
            item.StartAtack = true;
        }
    }
}
