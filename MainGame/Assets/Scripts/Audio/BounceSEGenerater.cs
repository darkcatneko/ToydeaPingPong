using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSEGenerater : CollisionManager
{
    protected override void onCollisionTag(Collision collision)
    {
        MainGameController.Instance.PlayerHitBounceObject();
    }
}
