using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerObjectSwitch : MonoBehaviour
{
    [SerializeField] private GameObject markerObject_;
    void Start()
    {
        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(turnOnMarker);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(turnOffMarker);
    }

    private void turnOffMarker()
    {
        markerObject_.SetActive(false);
    }
    private void turnOnMarker()
    {
        markerObject_.SetActive(true);
    }
}
