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
    private void Start()
    {
        initAssetAudioClip();
    }
    private void initAssetAudioClip()
    {
        bounceObjectSE_ = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/BounceObject.mp3");
    }
}
