using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnerManager : MonoBehaviour
{
    [SerializeField] private CarrotSpawner[] carrotSpawners_;
    [SerializeField] private GameObject carrotObject_;
    [SerializeField] private int lastActiveSpawner_ = -1;
    private class spawnerSourceClass
    {
        public List<int> spawnerSource_ = new List<int>() { 0, 1, 2, 3 };
    }
    void Start()
    {
        MainGameController.Instance.MainGameEvents_.DebutRaceStartEvent.AddListener(callNextSpawnerToSpawn);
        MainGameController.Instance.MainGameEvents_.PlayerEatCarrotEvent.AddListener(callNextSpawnerToSpawn);
    }
    private void callNextSpawnerToSpawn()
    {
        var spawnerPoolClass = new spawnerSourceClass();
        var spawnerPool = spawnerPoolClass.spawnerSource_;
        if (lastActiveSpawner_ >= 0) spawnerPool.RemoveAt(lastActiveSpawner_);
        var randomSpawnerPool = Random.Range(0, spawnerPool.Count);
        carrotSpawners_[spawnerPool[randomSpawnerPool]].SpawnACarrotInArea(carrotObject_);
        lastActiveSpawner_ = spawnerPool[randomSpawnerPool];
    }

}