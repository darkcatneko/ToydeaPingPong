using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem speedParticle_;
    [SerializeField] private ParticleSystem staminaParticle_;
    [SerializeField] private ParticleSystem strengthParticle_;
    [SerializeField] private ParticleSystem intelligenceParticle_;
    [SerializeField] private ParticleSystem allTrainingParticle_;
    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.TrainingEvent.AddListener(callParticle);
    }
    private void callParticle(Attributes attributes,int i)
    {
        var playerPos = MainGameController.Instance.PlayerObject.transform.position;
        switch (attributes)
        {
            case Attributes.Speed:
                speedParticle_.gameObject.transform.position = getParticlePositionByPlayer(speedParticle_.gameObject, playerPos); 
                speedParticle_.Play();
                return;
            case Attributes.Stamina:
                staminaParticle_.gameObject.transform.position = getParticlePositionByPlayer(staminaParticle_.gameObject, playerPos);
                staminaParticle_.Play();
                return;
            case Attributes.Strength:
                strengthParticle_.gameObject.transform.position = getParticlePositionByPlayer(strengthParticle_.gameObject, playerPos);
                strengthParticle_.Play();
                return;
            case Attributes.Intelligence:
                intelligenceParticle_.gameObject.transform.position = getParticlePositionByPlayer(intelligenceParticle_.gameObject, playerPos);
                intelligenceParticle_.Play();
                return;
            case Attributes.All:
                allTrainingParticle_.gameObject.transform.position = getParticlePositionByPlayer(allTrainingParticle_.gameObject, playerPos);
                allTrainingParticle_.Play();
                return;
        }
    }
    private Vector3 getParticlePositionByPlayer(GameObject particleObject,Vector3 playerPos)
    {
       return yToCustomVecter3(getObjectYPos(particleObject.gameObject), playerPos);
    }
    private Vector3 yToCustomVecter3(float customY,Vector3 target)
    {
        return new Vector3(target.x, customY, target.z);
    }
    private float getObjectYPos(GameObject gameObject)
    {
        return gameObject.gameObject.transform.position.y;
    }
}
