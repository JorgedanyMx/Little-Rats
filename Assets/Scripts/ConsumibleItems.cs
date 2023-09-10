using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumibleItems : MonoBehaviour
{
    public Sprite[] stateSprites;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SpriteRenderer sp;
    GRAPESSTATE grapesstate=GRAPESSTATE.FULL;

    private void OnEnable()
    {
        SetGrapesState(true);
        grapesstate = GRAPESSTATE.FULL;
    }
    public void SetGrapesState(bool isFUll)
    {
        if (isFUll)
        {
            grapesstate = GRAPESSTATE.FULL;
            sp.sprite = stateSprites[0];
        }
        else
        {
            grapesstate = GRAPESSTATE.EMPTY;
            sp.sprite = stateSprites[1];
        }
    }
}
public enum GRAPESSTATE
{
    FULL,EMPTY
};
