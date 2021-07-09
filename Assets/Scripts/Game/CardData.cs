using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData", order = 1)]
public class CardData : ScriptableObject
{
    [Serializable]
    public class EffectData
    {
        public int Id;
        public string Text;
    }

    [SerializeField] int Id;
    [SerializeField] string Name;
    [SerializeField] int Cost;
    [SerializeField] int Power;
    [SerializeField] int Toughness;
    [SerializeField] List<EffectData> Effect;

    public int GetId { get { return Id; } }
    public string GetName { get { return Name; } }
    public int GetCost{ get { return Cost; } }
    public int GetPower { get { return Power; } }
    public int GetToughness { get { return Toughness; } }
    public List<EffectData> GetEffect { get { return Effect; } }

#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        Cost = cost;
        Power = power;
        Toughness = toughness;
    }
#endif
}