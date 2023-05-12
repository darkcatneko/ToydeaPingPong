using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] blockers = new GameObject[0];
    [SerializeField] private GameObject blockerIcons_;

    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.PlayerShouldRankUpEvent.AddListener(turnOffBlockers);
        MainGameController.Instance.MainGameEvents_.PlayerRankedUpEvent.AddListener(turnOnBlockers);
    }
    private void turnOffBlockers()
    {
        foreach (var blocker in blockers)
        {
            blocker.SetActive(false);
        }
        blockerIcons_.SetActive(false);
    }
    private void turnOnBlockers()
    {
        foreach (var blocker in blockers)
        {
            blocker.SetActive(true);
        }
        blockerIcons_.SetActive(true);
    }
}
