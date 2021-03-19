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
    public GameObject border;
    public Card card;

    public void UpdateUI(Card card) {
        this.card = card;

        if(card != null) {
            nameText.text = card.displayName;

            if(card is PlantatorCard) {
                PlantatorCard p = card as PlantatorCard;
                effectText.text = $"{p.GetEffectString()}";
            } else if(card is PlantCard) {
                PlantCard p = card as PlantCard;
                effectText.text = $"G: {p.GetProfitValue()}";
            } else if(card is AssetCard) {
                AssetCard p = card as AssetCard;
                effectText.text = $"THIS IS ASSET";
            }
        } else {
            nameText.text = "";
            effectText.text = $"";
        }
    }
}
