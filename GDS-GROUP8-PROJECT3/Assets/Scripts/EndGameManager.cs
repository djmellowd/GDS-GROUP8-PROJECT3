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
    [SerializeField] private bool activeHologramTest;
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
            if (IsAllMissionComplete() || activeHologramTest)
            {
                hologram.SetActive(true);
                LookAtPlayer();
                textBoxManager.ActiveBox(hologramText, hologramTime);

                LookAtPlayer();
                firstAwake = false;
                audioSource.Play();
                StartCoroutine(StartAttackPlayer(audioSource.clip.length));
            }
        }
        if (miniGuns[0].IsDestory && miniGuns[1].IsDestory)
        {
            hudManager.GoToEnd();
        }

    }

    private void LookAtPlayer()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.x = 0;
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
            item.gameObject.SetActive(true);
            item.StartAtack = true;
        }
    }
}
