using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrainingTrigger : TriggerManager
{
    [SerializeField] private Attributes thisTrainingAttributes = new Attributes();
    [SerializeField] private int trainingAddAmount_ = 50;

    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.TrainingEvent(thisTrainingAttributes, trainingAddAmount_);
    }
    
}


