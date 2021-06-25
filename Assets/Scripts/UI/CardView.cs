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

        //Linq���g���āA�֌W����J�[�h���ʂ��������Ă���
        _text.text = "";
        var EffectList = GameManager.EffectMaster.Where(ef => ef.CardId == id).Select(ef => ef.Text);
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
