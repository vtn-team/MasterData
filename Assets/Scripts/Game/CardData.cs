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

    [SerializeField] int id;
    [SerializeField] new string name;
    [SerializeField] int cost;
    [SerializeField] int power;
    [SerializeField] int toughness;
    [SerializeField] List<EffectData> effect;

    public int Id
    {
        get => id;
        set
        {
            id = value;
        }
    }

    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }

    public int Cost
    {
        get => cost;
        set
        {
            cost = value;
        }
    }

    public int Power
    {
        get => power;
        set
        {
            power = value;
        }
    }

    public int Toughness
    {
        get => toughness;
        set
        {
            toughness = value;
        }
    }

    public List<EffectData> Effect
    {
        get => effect;
        set
        {
            effect = value;
        }
    }

#if UNITY_EDITOR
    public void SetData(int cost, int power, int toughness)
    {
        this.cost = cost;
        this.power = power;
        this.toughness = toughness;
    }
#endif
}