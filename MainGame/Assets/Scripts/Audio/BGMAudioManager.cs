using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        MainGameController.Instance.MainGameEvents_.GameStartEvent.AddListener(playGameBgm);
    }
    private void playGameBgm()
    {
        audioSource.Play();
    }
}
