using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    void Start()
    {
        playerData.target = Vector3.zero;
    }
    void Update()
    {
        playerData.target = GetMouseWorldPosition2D();
    }
    Vector3 GetMouseWorldPosition2D()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
}
