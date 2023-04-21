using PlasticPipe.PlasticProtocol.Messages;
using System.Collections;
using System.Collections.Generic;
using UmaNamespace;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [SerializeField]public RoundData ThisRound;
    public int WhichRound = 0;
    public float EarnedPriceMoney = 0; 
    
}