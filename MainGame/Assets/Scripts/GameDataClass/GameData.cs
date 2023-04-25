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
    [SerializeField]public List<RoundData> RoundDatas = new List<RoundData>();
    public int WhichRound = 0;

    
}