using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceSkillTrigger : CollisionManager
{
    [SerializeField] public int DistanceFoward;
    protected override void onCollisionTag(Collision collision)
    {
        MainGameController.Instance.RaceSkillActivate(DistanceFoward);
    }
}
