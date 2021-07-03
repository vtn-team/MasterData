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
    public int GetId { get => Id; }
    [SerializeField] string Name;
    public string GetName { get => Name; }
    [SerializeField] int Cost;
    public int GetCost { get => Cost; }
    [SerializeField] int Power;
    public int GetPower { get => Power; }
    [SerializeField] int Toughness;
    public int GetToughness { get => Toughness; }
    [SerializeField] List<EffectData> Effect;
    public List<EffectData> GetEffect { get => Effect; }



#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        Cost = cost;
        Power = power;
        Toughness = toughness;
    }
#endif
}