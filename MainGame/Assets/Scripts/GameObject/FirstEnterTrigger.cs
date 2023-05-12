using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnterTrigger : TriggerManager
{
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.PlayerFirstEnterField();
    }
}
