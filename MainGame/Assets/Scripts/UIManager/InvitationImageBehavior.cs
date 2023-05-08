using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvitationImageBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 finalPOS_;
    [SerializeField] private float animationSpeed_ = 0.5f;

    public void MoveThisImage()
    {
        this.gameObject.GetComponent<Image>().rectTransform.DOMove(finalPOS_, animationSpeed_);
    }
}
