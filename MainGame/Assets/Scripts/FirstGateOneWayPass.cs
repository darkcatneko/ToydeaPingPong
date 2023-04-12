using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGateOneWayPass : MonoBehaviour
{
    [Header("一方通行")]
    [SerializeField] private Collider rightGate_;
    [SerializeField] private Collider leftGate_;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rightGate_.isTrigger = true;
            leftGate_.isTrigger = true;
        }
    }
}
