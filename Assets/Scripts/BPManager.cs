using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPManager : MonoBehaviour
{
    public PlayerData playerData;
    public Animator anim;
    public void UpdateState()
    {
        switch (playerData.playerState)
        {
            case PLAYERSTATE.CLOSINGBP:
                anim.Play("BackpackClose");
                break;
            case PLAYERSTATE.OPENINGBP:
                anim.Play("BackpackOpen");
                break;
        }
    }
}
