using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Vector3 target = Vector3.zero;
    public Vector3 cameraPos = new Vector3(0f, 0f, -10f);
    public float smoothSpeed = 10.0f;  // Velocidad de suavizado
    private bool endGame = false;
    public PLAYERSTATE playerState=PLAYERSTATE.RATMODE;
    public float factorDificulty = 1f;

    public void SetEnd()
    {
        endGame = true;
    }
}
public enum PLAYERSTATE
{
    RATMODE,
    OPENINGBP,
    BACKPACKMODE,
    CLOSINGBP,
    PAUSE
};
