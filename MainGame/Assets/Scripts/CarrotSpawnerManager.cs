using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnerManager : MonoBehaviour
{
    [SerializeField] private CarrotSpawner[] carrotSpawners_;
    [SerializeField] private GameObject carrotObject;
    [SerializeField] private int lastActiveSpawner = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        MainGameController.Instance.MainGameEvents_.DebutRaceStartEvent.AddListener(gameStartSpawnFirstCarrot);
        MainGameController.Instance.MainGameEvents_.PlayerEatCarrotEvent.AddListener(callNextSpawnerToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void gameStartSpawnFirstCarrot()
    {
        carrotSpawners_[0].SpawnACarrotInArea(carrotObject);
    }
    private void callNextSpawnerToSpawn()
    {
        var randomSpawnerID = Random.Range(0, 4);
        while (randomSpawnerID == lastActiveSpawner)
        {
            randomSpawnerID = Random.Range(0, 4);
        }
        carrotSpawners_[randomSpawnerID].SpawnACarrotInArea(carrotObject);
        lastActiveSpawner = randomSpawnerID;
    }
}
