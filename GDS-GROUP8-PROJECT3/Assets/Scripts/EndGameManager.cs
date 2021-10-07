using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private List<EndGameButton> endGameButtons;

    private bool firstAwake=true;

    private void Update()
    {
        if (firstAwake)
        {
            if (IsAllMissionComplete())
            {
                Debug.Log("KONIEC GRY");
                firstAwake = false;
            }
        }
        
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
}
