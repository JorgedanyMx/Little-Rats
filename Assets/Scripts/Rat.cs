using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public Sprite[] stateSprites;
    public float reaptingRateSound=5f;
    public AudioClip[] ratIdleSounds;
    public PlayerData playerData;

    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private AudioSource audioSource;
    RATSTATES ratState;
    private float timeStateMax = 1f;
    private float counterSeg=0f;
    void Start()
    {
        ratState = RATSTATES.CURIOUS;
        sp = GetComponent<SpriteRenderer>();
        UpdateRatSprite();
        counterSeg = timeStateMax;
        StartCoroutine("DelayRatSound");
        StartCoroutine("RatCounter");
    }

    IEnumerator RatCounter()
    {
        yield return new WaitForSeconds(.1f);
        counterSeg -= .1f;
        ChangeState();
        StartCoroutine("RatCounter");
    }
    private void ChangeState()
    {
        if (counterSeg <= 0.0f)
        {
            if(ratState!= RATSTATES.ANGRY)
            {
                ratState++;
                counterSeg = timeStateMax * playerData.factorDificulty;
                UpdateRatSprite();
            }
            else
            {
                RatAttack();
                StopAllCoroutines();
                Destroy(transform.gameObject);
            }
        }
    }
    private void RatAttack()
    {
        Debug.Log("RataAtaca");
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
    IEnumerator DelayRatSound()
    {
        float randomDelay = Random.Range(0f, 3f);
        yield return new WaitForSeconds(randomDelay+reaptingRateSound);
        int randomSound = Random.Range(0, ratIdleSounds.Length-1);
        PlayModPitchSound(ratIdleSounds[randomSound]);
        StartCoroutine("DelayRatSound");

    }
    private void PlayModPitchSound(AudioClip clipS)
    {
        float randomPitch = Random.Range(0f, 0.2f) + 0.9f;
        audioSource.pitch = randomPitch;
        audioSource.clip = clipS;
        audioSource.Play();
    }
}
public enum RATSTATES
{
    CURIOUS, CUTE1, CUTE2,ANGRY
};
