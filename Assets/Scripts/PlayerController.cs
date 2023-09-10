using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;
    public GameEvent switchModeEvent;
    public LayerMask lm;

    public float moveSpeed = 500.0f;  // Velocidad de movimiento de la cámara
    public float edgeThreshold = 0.1f;  // Porcentaje de la pantalla en el que se considera el borde (0.1 = 10%)
    public float yMax = 3.0f;  // Límite máximo en el eje Y
    public float yMin = 0.0f;  // Límite mínimo en el eje Y

    private float xCamPos=0;
    void Start()
    {
        playerData.target = Vector3.zero;
        xCamPos = Camera.main.transform.position.x;
    }
    void Update()
    {
        playerData.target = GetMouseWorldPosition2D();
        ChooseMode();
        SelectGrapes();
        if (playerData.playerState == PLAYERSTATE.RATMODE)
        {
            MoveCameraWithMouseOnEdge();
        }
    }
    Vector3 GetMouseWorldPosition2D()
    {
        if (!IsMouseInsideWindow())
            return playerData.target;

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
                    playerData.playerState = PLAYERSTATE.OPENINGBP;
                    Invoke("OpeningBP",1f);

                    break;
                case PLAYERSTATE.BACKPACKMODE:
                    playerData.playerState = PLAYERSTATE.CLOSINGBP;
                    Invoke("ClosingBP", 1f);
                    break;
            }
        }
        switchModeEvent.Raise();
    }
    private void OpeningBP()
    {
        playerData.playerState = PLAYERSTATE.BACKPACKMODE;
        switchModeEvent.Raise();
    }
    private void ClosingBP()
    {
        playerData.playerState = PLAYERSTATE.RATMODE;
        switchModeEvent.Raise();
    }

    private void SelectGrapes()
    {
        if (Input.GetMouseButtonDown(0) && playerData.playerState== PLAYERSTATE.BACKPACKMODE)
        {
            Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 10f,lm);
            if (hit)
            {
                ConsumibleItems grapes = hit.transform.gameObject.GetComponent<ConsumibleItems>();
                if (grapes!=null){
                    grapes.SetGrapesState(false);
                }
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log("Clicked on: " + clickedObject.name);
            }
        }
    }
    void MoveCameraWithMouseOnEdge()
    {
        if (!IsMouseInsideWindow())
            return;
        float edgeZoneUp = Screen.height * (1 - edgeThreshold);
        float edgeZoneDown = Screen.height * edgeThreshold;
        if (Input.mousePosition.y > edgeZoneUp)
        {
            float ytmpPos = Camera.main.transform.position.y+(moveSpeed * Time.deltaTime);
            ytmpPos = Mathf.Clamp(ytmpPos, yMin, yMax);
            playerData.cameraPos= new Vector3(xCamPos, ytmpPos, -10f);
        }
        if (Input.mousePosition.y < edgeZoneDown)
        {
            float ytmpPos = Camera.main.transform.position.y - (moveSpeed * Time.deltaTime);
            ytmpPos = Mathf.Clamp(ytmpPos, yMin, yMax);
            playerData.cameraPos = new Vector3(xCamPos, ytmpPos, -10f);
        }
        Camera.main.transform.position = playerData.cameraPos;
    }
    private bool IsMouseInsideWindow()
    {
        return Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width &&
               Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height;
    }
}
