using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed_;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0,1f,0)*rotateSpeed_*Time.deltaTime);
    }
}
