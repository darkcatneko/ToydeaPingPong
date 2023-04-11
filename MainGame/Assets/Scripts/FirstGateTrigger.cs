using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject FirstGateObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FirstGateObject.SetActive(true);
        }
    }
}
