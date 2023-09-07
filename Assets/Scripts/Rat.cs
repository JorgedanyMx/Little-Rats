using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Sprite[] stateSprites;
    [SerializeField] private SpriteRenderer sp;
    RATSTATES ratState;
    void Start()
    {
        ratState = RATSTATES.CURIOUS;
        sp = GetComponent<SpriteRenderer>();
        UpdateRatSprite();
    }
private void UpdateRatSprite()
    {
        switch (ratState)
        {
            case RATSTATES.CURIOUS:
                sp.sprite = stateSprites[0];
                break;
            case RATSTATES.CUTE1:
                sp.sprite = stateSprites[1];
                break;
            case RATSTATES.CUTE2:
                sp.sprite = stateSprites[2];
                break;
            case RATSTATES.ANGRY:
                sp.sprite = stateSprites[3];
                break;
        }
    }
}
public enum RATSTATES
{
    CURIOUS, CUTE1, CUTE2,ANGRY
};
