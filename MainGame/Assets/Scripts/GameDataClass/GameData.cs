//using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UmaNamespace;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField]
    public RoundData ThisRound;

    [SerializeField]
    public List<RoundData> RoundDatas = new List<RoundData>();

    public int WhichRound = 1;
    
    public float GetTrainingPercentage(Attributes attributes)
    {
        switch (attributes)
        {
            case Attributes.Speed:
                return ThisRound.ThisUmaTraingData.Speed / ThisRound.ThisUmaTraingData.MaxBar;
            case Attributes.Stamina:
                return ThisRound.ThisUmaTraingData.Stamina / ThisRound.ThisUmaTraingData.MaxBar;
            case Attributes.Strength:
                return ThisRound.ThisUmaTraingData.Strength / ThisRound.ThisUmaTraingData.MaxBar;
            case Attributes.Intelligence:
                return ThisRound.ThisUmaTraingData.Intelligence / ThisRound.ThisUmaTraingData.MaxBar;
            default:
                return 0;
        }

    }

}