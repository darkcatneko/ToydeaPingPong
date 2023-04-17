using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UmaNamespace
{
    [CreateAssetMenu(fileName = "NewUma", menuName = "Uma")]
    public class UmaScriptableObject : ScriptableObject
    {
        [SerializeField] public UmaData ThisUma;
    }
}



[System.Serializable]
public class UmaData
{
    [SerializeField] public Sprite UmaPicture;
    [SerializeField] public string UmaName;
    [SerializeField] public int UmaId; 
}