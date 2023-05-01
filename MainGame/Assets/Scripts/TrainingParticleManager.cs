using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem speedParticle_;
    [SerializeField] private ParticleSystem staminaParticle_;
    [SerializeField] private ParticleSystem strengthParticle_;
    [SerializeField] private ParticleSystem intelligenceParticle_;
    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.TrainingEvent.AddListener(callParticle);
    }
    private void callParticle(Attributes attributes,int i)
    {
        switch(attributes)
        {
            case Attributes.Speed:
                speedParticle_.Play();
                return;
            case Attributes.Stamina:
                staminaParticle_.Play();
                return;
            case Attributes.Strength:
                strengthParticle_.Play();
                return;
            case Attributes.Intelligence:
                intelligenceParticle_.Play();
                return;
        }
    }
}
