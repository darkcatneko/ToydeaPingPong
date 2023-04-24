using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceInfo 
{
    public RaceLength RaceLength;
    public int RaceReward;
    public RaceInfo(RaceLength raceLength, int raceReward)
    {
        RaceLength = raceLength;
        RaceReward = raceReward;
    }
}

public class RaceInfos
{
    public List<RaceInfo> RaceInfoList = new List<RaceInfo>();
    
    public RaceInfo ShortRaceInfo = new RaceInfo(RaceLength.Short,170000000);
    public RaceInfo MileRaceInfo = new RaceInfo(RaceLength.Mile, 180000000);
    public RaceInfo MiddleRaceInfo = new RaceInfo(RaceLength.Middle, 300000000);
    public RaceInfo LongRaceInfo = new RaceInfo(RaceLength.Long, 500000000);
    public RaceInfo DirtRaceInfo = new RaceInfo(RaceLength.Dirt, 120000000);//必須找一個時間學excel讀法

    public RaceInfos()
    {
        InfoInit();
    }

    public void InfoInit()
    {
        RaceInfoList.Add(ShortRaceInfo);
        RaceInfoList.Add(MileRaceInfo);
        RaceInfoList.Add(DirtRaceInfo);
        RaceInfoList.Add(MiddleRaceInfo);
        RaceInfoList.Add(LongRaceInfo);
    }

    public int GetRacePrice(RaceLength raceLength)
    {
        for (int i = 0; i < RaceInfoList.Count; i++)
        {
            if (RaceInfoList[i].RaceLength== raceLength)
            {
                return RaceInfoList[i].RaceReward;
            }
        }
        return 0;
    }
}
