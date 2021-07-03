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

    public int GetID => Id;
    public string GetName => Name;
    public int GetCost => Cost;
    public int GetPower => Power;
    public int GetToughness => Toughness;
    public List<EffectData> GetEffect => Effect; 


#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        Cost = cost;
        Power = power;
        Toughness = toughness;
    }
#endif
}