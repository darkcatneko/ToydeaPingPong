using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainingData
{
    public int Speed = 0;
    public int Stamina = 0;
    public int Strength = 0;
    public int Intelligence = 0;
    public float MaxBar = 1000;
    //public int EnterRaceChance = 0;
    public bool CanEnterBonusStage = false;
    [field:SerializeField]public UmaRank ThisUmaRank { get; private set; } 
    public void AddAttributes(Attributes attributes,int plusAmount )
    {
        switch (attributes)
        {
            case Attributes.Speed:
                plusSpeed(plusAmount);
                break;
            case Attributes.Stamina:
                plusStamina(plusAmount);
                break;
            case Attributes.Strength:
                plusStrength(plusAmount);
                break;
            case Attributes.Intelligence:
                plusIntelligence(plusAmount);
                break;
            default:
                break;
        }
        rankUpChallangeStart();
    }
    private void rankUpChallangeStart()
    {
        if (Speed == MaxBar && Stamina == MaxBar && Strength == MaxBar && Intelligence == MaxBar)
        {
            CanEnterBonusStage = true;
            MainGameController.Instance.PlayerShouldRankUp();
        }
    }
    public void RankUp()
    {
        if (Speed == MaxBar && Stamina == MaxBar && Strength == MaxBar && Intelligence == MaxBar)
        {
            ThisUmaRank = (UmaRank)((int)ThisUmaRank + 1);
            Speed = Stamina = Strength = Intelligence = 0;
        }      
    }

    private void plusSpeed(int plusAmount)
    {
        Speed = Mathf.Clamp(Speed + plusAmount, 0, (int)MaxBar);
    }
    private void plusStamina(int plusAmount)
    {
        Stamina = Mathf.Clamp(Stamina + plusAmount, 0, (int)MaxBar);
    }
    private void plusStrength(int plusAmount)
    {
        Strength = Mathf.Clamp(Strength + plusAmount, 0, (int)MaxBar);
    }
    private void plusIntelligence(int plusAmount)
    {
        Intelligence = Mathf.Clamp(Intelligence + plusAmount, 0, (int)MaxBar);
    }

}
public enum Attributes
{
    Speed,
    Stamina,
    Strength,
    Intelligence,
}
[System.Serializable]
public enum UmaRank { E, D, C, B, A, S, SS }