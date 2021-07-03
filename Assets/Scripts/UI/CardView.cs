using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardView : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text _name;
    [SerializeField] TMPro.TMP_Text _text;

    [SerializeField] TMPro.TMP_Text _cost;
    [SerializeField] TMPro.TMP_Text _power;
    [SerializeField] TMPro.TMP_Text _toughness;
    [SerializeField] CardData[] cardData = null;

    private void Start()
    {
        TempViewData(cardData[0].GetID);
    }

    public void ViewData(int id)
    {
        var card = GameManager.CardMaster.Single(c => c.Id == id);
        _cost.text = card.Cost.ToString();

        if (card.Power == -1)
        {
            _power.text = "";
        }
        else
        {
            _power.text = card.Power.ToString();
        }

        if (card.Toughness == -1)
        {
            _toughness.text = "";
        }
        else
        {
            _toughness.text = card.Toughness.ToString();
        }

        _name.text = card.Name.ToString();

        //Linqを使って、関係あるカード効果を検索してくる
        _text.text = "";
        var EffectList = GameManager.EffectMaster.Where(ef => ef.CardId == id).Select(ef => ef.Text);
        if (EffectList.Count() == 0)
        {
            _text.text = "効果なし";
        }
        else
        {
            foreach (var effect in EffectList)
            {
                _text.text += effect;
            }
        }
    }

    public void TempViewData(int id)
    {
        var card = cardData.Single(c => c.GetID == id);
        _cost.text = card.GetCost.ToString();

        if (card.GetPower == -1)
        {
            _power.text = "";
        }
        else
        {
            _power.text = card.GetPower.ToString();
        }

        if (card.GetToughness == -1)
        {
            _toughness.text = "";
        }
        else
        {
            _toughness.text = card.GetToughness.ToString();
        }

        _name.text = card.GetName.ToString();

        //Linqを使って、関係あるカード効果を検索してくる
        _text.text = "";
        var EffectList = cardData.Where(ef => ef.GetID == id).Select(ef => ef.GetEffect);
        if (EffectList.Count() == 0)
        {
            _text.text = "効果なし";
        }
        else
        {
            foreach (var effect in EffectList)
            {
                _text.text += effect[0].Text;
            }
        }
    }
}
