using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEndTrigger : TriggerManager
{
    protected override string customTag_ => "Player";
    protected override string customTag2_ => "Enemy";
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.PlayerPassGoal();
    }
    protected override void onTriggerEnterOther(Collider other)
    {
        MainGameController.Instance.EnemyPassGoal();
        MainUiController.Instance.CallUpdateRaceInfo();
        other.gameObject.transform.position = new Vector3(1000f, 1000f, 1000f);
    }
}
