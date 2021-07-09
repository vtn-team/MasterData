using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList", menuName = "ScriptableObjects/CardList", order = 1)]
public class CardList : ScriptableObject
{
    [SerializeField] List<CardData> _cardList;
    
    public List<CardData> List => _cardList;
    public CardData Search(int id)
    {
        return _cardList.Single(c => c.Id == id);
    }
}