using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TrainingTrigger : TriggerManager
{
    [SerializeField] private Attributes thisTrainingAttributes = new Attributes();
    [SerializeField] private int trainingAddAmount_ = 50;
    [SerializeField] private SpriteRenderer trainingIcon_;
    [SerializeField] private float flashSpeed_ = 0.2f;
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.TrainingEvent(thisTrainingAttributes, trainingAddAmount_);
        trainingIcon_.color = Color.white;
        CancelInvoke();
        Invoke("returnToBlack", flashSpeed_);
    }
   private void returnToBlack()
    {
        trainingIcon_.color = new Color(0.4f, 0.4f, 0.4f, 1f);
    }
        
   

}


