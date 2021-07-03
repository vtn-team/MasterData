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

    [SerializeField]GameManager gm;
    public void ViewData(int id)
    {
        var card = gm.cardDate.Single(c => c.GetId == id);
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

        //Linq���g���āA�֌W����J�[�h���ʂ��������Ă���
        _text.text = "";
        var EffectList = gm.cardDate[id - 1].GetEffect.Where(ef => ef.Id == id).Select(ef => ef.Text);
        if (EffectList.Count() == 0)
        {
            _text.text = "���ʂȂ�";
        }
        else
        {
            foreach (var effect in EffectList)
            {
                _text.text += effect;
            }
        }
    }
}
