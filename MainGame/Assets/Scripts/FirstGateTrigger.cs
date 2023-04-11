using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject firstGateObject_;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            firstGateObject_.SetActive(true);
        }
    }
}
