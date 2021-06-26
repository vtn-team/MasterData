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
    public int ID { get => Id; }
    public string CName { get => Name; }
    public int CCost { get => Cost; }
    public int CPower { get => Power; }
    public int CToughness { get => Toughness; }
    public List<EffectData> CEffect { get => Effect; }

#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        Cost = cost;
        Power = power;
        Toughness = toughness;
    }
#endif
}