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
        public string Text;
    }

    [SerializeField] int id;
    [SerializeField] new string name;
    [SerializeField] int cost;
    [SerializeField] int power;
    [SerializeField] int toughness;
    [SerializeField] List<EffectData> effect;


    public int Id => id;
    public string Name => name;
    public int Cost => cost;
    public int Power => power;
    public int Toughness => toughness;
    public List<EffectData> Effect => effect;


#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        this.cost = cost;
        this.power = power;
        this.toughness = toughness;
    }
#endif
}