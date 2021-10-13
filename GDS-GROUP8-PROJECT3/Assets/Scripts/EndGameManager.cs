using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private List<EndGameButton> endGameButtons;
    [SerializeField] private List<MiniGun> miniGuns;
    [SerializeField] private GameObject hologram;
    [SerializeField] private AudioSource audioSource;
     private TextBoxManager textBoxManager;

    private bool firstAwake=true;

    private void Start()
    {
        textBoxManager = FindObjectOfType<TextBoxManager>();
    }
    private void Update()
    {
        if (firstAwake)
        {
            if (IsAllMissionComplete())
            {
                hologram.SetActive(true);
                firstAwake = false;
                audioSource.Play();
                StartCoroutine(StartAttackPlayer(audioSource.clip.length));
            }
        }
        
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
