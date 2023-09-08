using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject bg1, bg2;
    public PlayerData playerData;

    public void SwitchScene()
    {
        if (playerData.playerState == PLAYERSTATE.RATMODE)
        {
            bg2.SetActive(false);
        }
        else
        {
            bg2.SetActive(true);
        }
    }

}
