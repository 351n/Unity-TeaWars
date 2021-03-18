using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CardGameObject : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Sprite image;
    public TextMeshProUGUI effectText;

    internal void UpdateUI(Card card) {
        nameText.text = card.displayName;

        if(card is PlantatorCard) {
            PlantatorCard p = card as PlantatorCard;
            effectText.text = $"{p.GetEffectString()}";
        } else if(card is PlantCard) {
            PlantCard p = card as PlantCard;
            effectText.text = $"G: {p.GetProfitValue()}";
        }
    }
}
