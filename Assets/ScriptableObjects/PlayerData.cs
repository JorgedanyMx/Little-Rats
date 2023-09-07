using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public Vector3 target = Vector3.zero;
    public float smoothSpeed = 10.0f;  // Velocidad de suavizado
}
