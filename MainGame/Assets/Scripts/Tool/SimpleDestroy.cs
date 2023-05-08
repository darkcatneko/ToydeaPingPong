using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime_;
    private void Start()
    {
        Destroy(this.gameObject, destroyTime_);
    }
}
