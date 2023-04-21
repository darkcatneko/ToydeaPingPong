using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint_;
    [SerializeField] private GameObject ballPrefab_;

    private void Start()
    {
        spawn_Ball();
        //MainGameController.Instance.ListenEvent(GameEvent.GameRestart,spawn_Ball);
        MainGameController.Instance.MainGameEvents_.RaceStartEvent.AddListener(spawn_Ball);
    }

    private void spawn_Ball()
    {
        MainGameController.Instance.PlayerObject = Instantiate<GameObject>(ballPrefab_, spawnPoint_.transform.position, Quaternion.identity);
        MainGameController.Instance.SetPlayerRigidbody();
    }
    
}
