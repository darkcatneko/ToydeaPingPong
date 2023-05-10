using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class SEAudioManager : MonoBehaviour
{
    [SerializeField]private AudioClip bounceObjectSE_;
    private AudioClip eatCarrotSE_;
    private AudioClip raceEndSE_;
    private AudioClip raceShouldStart_;
    private AudioClip triggerTraining_;
    private GameObject audioSourceObjectPrefab_;
    [SerializeField] private PoolManager poolmanager_;
    [SerializeField] float destroyWaitTime = 3;
    private void Start()
    {
        seAudioManagerInit();
        MainGameController.Instance.MainGameEvents_.PlayerHitBounceObjectEvent.AddListener(callBounceObjectSE);
    }   
    private void seAudioManagerInit()
    {
        assetAudioClipInit();
        audioSourceObjectPrefabInit();
    }
    private void audioSourceObjectPrefabInit()
    {
        audioSourceObjectPrefab_ = getAudioSourceObjectPrefab();
    }
   
    private async void assetAudioClipInit()
    {
        bounceObjectSE_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/BounceObjectSE");
        eatCarrotSE_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/EatCarrot");
    }
    private GameObject SpawnAudioSource()
    {
        PoolObjectDestroyer destroyer;
        var spawnedObject = poolmanager_.GetGameObject(audioSourceObjectPrefab_, Vector3.zero, Quaternion.identity);
        destroyer = spawnedObject.GetComponent<PoolObjectDestroyer>();
        destroyer.PoolManager = poolmanager_;
        if (destroyer != null)
        {
            destroyer.StartDestroyTimer(destroyWaitTime);
        }
        return spawnedObject;
    }
    private GameObject getAudioSourceObjectPrefab()
    {
        var gameobject = new GameObject();
        gameobject.name = "SEPlayer";
        var soundEffectPlayer = gameobject.AddComponent<AudioSource>();
        var destroyer = gameobject.AddComponent<PoolObjectDestroyer>();
        return gameobject;
    }    

    private void callBounceObjectSE()
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = bounceObjectSE_;
        audioPlayer.Play();
    }
}
