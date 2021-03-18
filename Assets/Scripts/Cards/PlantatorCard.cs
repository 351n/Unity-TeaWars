using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantatorCard : Card
{
    int level = 0;
    int[] cardsDrawn = { 1, 2 };
    int upgradeCost = 3;

    public PlantatorCard(string displayName, string id) : base(displayName, id) {
    }

    public void Upgrade() {
        if(level == 0) {
            level++;
        }
    }

    public int GetUpgradeCost() {
        if(level == 0)
            return upgradeCost;

        return -1;
    }

    public int GetCardsDrawnValue() {
        return cardsDrawn[level];
    }

    public override void Apply(PlayerController playerController) {
        Debug.Log($"Player hand before: {playerController.hand.Count}");
        for(int i = 0; i < cardsDrawn[level]; i++) {
            playerController.hand.Add(CardsController.instance.Draw());
        }
        Debug.Log($"Player hand after: {playerController.hand.Count}");
    }

    public override string ToString() {
        return $"{base.ToString()} {GetEffectString()}";
    }

    public string GetEffectString() {
        return $"D:{cardsDrawn[level]}";
    }
}
