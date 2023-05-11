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
        MainGameController.Instance.MainGameEvents_.PlayerEatCarrotEvent.AddListener(callEatCarrotSE);
        MainGameController.Instance.MainGameEvents_.PlayerPassGoalEvent.AddListener(callRaceEndSE);
        MainGameController.Instance.MainGameEvents_.PlayerShouldRankUpEvent.AddListener(callRaceShouldStartSE);
        MainGameController.Instance.MainGameEvents_.TrainingEvent.AddListener(callTrainingSE);
    }   
    private void seAudioManagerInit()
    {
        assetAudioClipInit();
        audioSourceObjectPrefabInit();
    }
    private async void assetAudioClipInit()
    {
        bounceObjectSE_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/BounceObjectSE");
        eatCarrotSE_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/EatCarrot");
        raceEndSE_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/RaceFinish");
        raceShouldStart_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/RaceShouldStart");
        triggerTraining_ = await AddressableSearcher.Instance.GetAddressableAsset<AudioClip>("Audio/TrainingTrigger");
    }
    private void audioSourceObjectPrefabInit()
    {
        audioSourceObjectPrefab_ = getAudioSourceObjectPrefab();
    }
    #region Call_SE_Event
    private void callBounceObjectSE()
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = bounceObjectSE_;
        audioPlayer.Play();
    }
    private void callEatCarrotSE()
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = eatCarrotSE_;
        audioPlayer.Play();
    }
    private void callRaceEndSE()
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = raceEndSE_;
        audioPlayer.Play();
    }
    private void callRaceShouldStartSE()
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = raceShouldStart_;
        audioPlayer.Play();
    }
    private void callTrainingSE(Attributes attributes,int amount)
    {
        var audioPlayer = SpawnAudioSource().GetComponent<AudioSource>();
        audioPlayer.clip = triggerTraining_;
        audioPlayer.Play();
    }
    #endregion
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
        soundEffectPlayer.volume = 0.35f;
        return gameobject;
    }    

   
}
