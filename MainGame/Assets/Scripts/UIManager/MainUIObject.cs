using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUIObject : MonoBehaviour
{
    [SerializeField] public Text NowRaceType;
    [SerializeField] public Text NowRaceRemainDistance;
    [SerializeField] public Text YourHorseHighestPossiblePlace;
    [SerializeField] public Text NowRaceCount;
    [SerializeField] public Text NowEarnedPoint;
    [SerializeField] public Text NowGameRound;
    void Start()
    {
        MainUiController.Instance.MainUIOBJ = this;
    }

    
    void Update()
    {
        
    }
}
