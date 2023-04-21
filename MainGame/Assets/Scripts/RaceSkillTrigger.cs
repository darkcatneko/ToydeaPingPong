using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSkillTrigger : TriggerManager
{
    [SerializeField] public int DistanceFoward;
    protected override void onTriggerEnterTag(Collider other)
    {
        //GameDataManager.Instance
    }
}
