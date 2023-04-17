using System.Collections;
using System.Collections.Generic;
using UmaNamespace;
using UnityEngine;

[System.Serializable]
public class RoundData
{
    [SerializeField] private UmaScriptableObject thisUmaSO_;
    public UmaData ThisUmaData => thisUmaSO_.ThisUma;
    public int ThisUmaNumber = 0;
}
