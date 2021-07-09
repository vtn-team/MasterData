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

    [SerializeField] int _id;
    [SerializeField] string _name;
    [SerializeField] int _cost;
    [SerializeField] int _power;
    [SerializeField] int _toughness;
    [SerializeField] List<EffectData> _effect;

    public int Id => _id;
    public string Name => _name;
    public int Cost => _cost;
    public int Power => _power;
    public int Toughness => _toughness;
    public List<EffectData> Effect => _effect;

#if UNITY_EDITOR
    public void SetId(int id)
    {
        _id = id;
    }
#endif
}