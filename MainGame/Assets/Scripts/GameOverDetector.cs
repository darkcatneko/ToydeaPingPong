using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : TriggerManager
{
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.GameOver();
        Destroy(other.gameObject);
    }
}
