using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGateTrigger : MonoBehaviour
{
    [Header("本体物件")]
    [SerializeField] private GameObject firstGateObject_;
    [Header("一方通行")]
    [SerializeField] private Collider rightGate_;
    [SerializeField] private Collider leftGate_;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //firstGateObject_.SetActive(true);
            rightGate_.isTrigger = false;
            leftGate_.isTrigger = false;
        }
    }
}
