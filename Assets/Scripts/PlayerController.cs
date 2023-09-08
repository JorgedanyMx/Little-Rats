using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public GameEvent switchModeEvent;
    public LayerMask lm;
    void Start()
    {
        playerData.target = Vector3.zero;
    }
    void Update()
    {
        playerData.target = GetMouseWorldPosition2D();
        ChooseMode();
        SelectGrapes();
    }
    Vector3 GetMouseWorldPosition2D()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
    private void ChooseMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (playerData.playerState)
            {
                case PLAYERSTATE.RATMODE:
                    playerData.playerState = PLAYERSTATE.BACKPACKMODE;
                    break;
                case PLAYERSTATE.BACKPACKMODE:
                    playerData.playerState = PLAYERSTATE.RATMODE;
                    break;
            }
        }
        switchModeEvent.Raise();
    }
    private void SelectGrapes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 10f,lm);
            if (hit)
            {
                Grapes grapes = hit.transform.gameObject.GetComponent<Grapes>();
                if (grapes!=null){
                    grapes.SetGrapesState(false);
                }
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log("Clicked on: " + clickedObject.name);
            }
        }
    }
}
