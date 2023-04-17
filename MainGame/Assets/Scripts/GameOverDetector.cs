using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDetector : TriggerManager
{
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.GameRestart();
        Destroy(other.gameObject);
    }
}
