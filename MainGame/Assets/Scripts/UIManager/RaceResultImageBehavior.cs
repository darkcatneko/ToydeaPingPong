using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;

public class RaceResultImageBehavior : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField]private Image thisImageRenderer_;
    [SerializeField]private Sprite[] resultSprites;
    [SerializeField] private Vector3 finalPos_;
    [SerializeField] private float animationTime_=0.3f;
    [SerializeField] private float fadeTime_=0.6f;

    public void CallResultImage(int rank)
    {
        thisImageRenderer_.sprite = resultSprites[rank-1];
        this.gameObject.SetActive(true);
        this.gameObject.transform.DOMove(finalPos_, animationTime_).OnComplete(startFadeCoroutine);
    }
    private void startFadeCoroutine()
    {
        StartCoroutine("startFade");
    }
    private IEnumerator startFade()
    {
        thisImageRenderer_.CrossFadeAlpha(0, fadeTime_, true);
        yield return new WaitForSeconds(fadeTime_);
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = spawnPos.transform.position;

    }
}
