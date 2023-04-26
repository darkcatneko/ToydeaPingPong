using System.Collections;
using System.Collections.Generic;
using UmaNamespace;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[System.Serializable]
public class RoundData
{
    [SerializeField]
    private UmaScriptableObject thisUmaSO_;

    public float EarnedPriceMoney = 0;

    public UmaData ThisUmaData => thisUmaSO_.ThisUma;
    public int ThisUmaNumber = 0;

    [SerializeField]
    public RaceData NowRace = new RaceData(RaceLength.None);

    [SerializeField]
    public List<RaceData> RaceList = new List<RaceData>();
    public void DebutRaceInit()
    {
        NowRace = new RaceData();
        MainUiController.Instance.CallUpdateRaceInfo();
    }

}
