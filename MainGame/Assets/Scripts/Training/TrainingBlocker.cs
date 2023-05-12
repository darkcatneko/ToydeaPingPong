using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingBlocker :  CollisionManager
{
    [SerializeField] private Attributes thisTrainingAttributes = new Attributes();
    [SerializeField] private int trainingAddAmount_ = 50;
    [SerializeField] private Material blockerMaterial_;
    [SerializeField] private float flashSpeed_ = 0.2f;
    protected override void onCollisionTag(Collision collision)
    {
        MainGameController.Instance.TrainingEvent(thisTrainingAttributes, trainingAddAmount_);
        blockerMaterial_.color = Color.white;
        CancelInvoke();
        Invoke("returnToBlack", flashSpeed_);
    }
    private void returnToBlack()
    {
        blockerMaterial_.color = new Color(0.4f, 0.4f, 0.4f, 1f);
    }
}
