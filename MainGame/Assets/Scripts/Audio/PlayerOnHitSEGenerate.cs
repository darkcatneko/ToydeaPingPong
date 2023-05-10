using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnHitSEGenerate : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MainGameController.Instance.PlayerHitBounceObject();
    }
}
