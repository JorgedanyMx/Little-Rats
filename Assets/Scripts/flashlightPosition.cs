using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPosition : MonoBehaviour
{
    public PlayerData playerData;
    

    void Update()
    {
        if (playerData.playerState == PLAYERSTATE.RATMODE)
        {
            SmoothFollow();
        }
        
    }
    void SmoothFollow()
    {
        Vector3 desiredPosition = playerData.target;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, playerData.smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;
    }
   
}
