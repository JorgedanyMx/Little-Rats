using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject bg1, bg2;
    public PlayerData playerData;

    void Start()
    {
        playerData.playerState = PLAYERSTATE.RATMODE;    
    }
    public void SwitchScene()
    {

        if (playerData.playerState == PLAYERSTATE.RATMODE)
        {
            bg2.SetActive(false);
            Camera.main.transform.position = playerData.cameraPos;
        }
        else
        {
            Camera.main.transform.position = new Vector3(0,0,-10f);
            bg2.SetActive(true);
        }
    }

}
