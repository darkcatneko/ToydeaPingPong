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
    }
    private void spawn_Ball()
    {
        var playerObj = MainGameController.Instance.PlayerObject;
        MainGameController.Instance.PlayerObject = Instantiate<GameObject>(ballPrefab_, spawnPoint_.transform.position, Quaternion.identity);

    }
}
