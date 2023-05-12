using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotTrigger : TriggerManager
{
    [SerializeField] private Attributes thisTrainingAttributes = new Attributes();
    [SerializeField] private int trainingAddAmount_ = 100;
    protected override void onTriggerEnterTag(Collider other)
    {
        MainGameController.Instance.TrainingEvent(thisTrainingAttributes, trainingAddAmount_);
        this.gameObject.SetActive(false);
        MainGameController.Instance.PlayerEatCarrot();
        
    }
}
