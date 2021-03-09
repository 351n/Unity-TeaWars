using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantatorCard : Card
{
    int level = 0;
    int[] cardsDrawn = { 1, 2 };
    int upgradeCost = 3;

    public void Upgrade() {
        if(level == 0) {
            level++;
        }
    }

    public int GetUpgradeCost() {
        if(level==0)
        return upgradeCost;

        return -1;
    }

    public override void Apply() {
        throw new System.NotImplementedException();
    }

    public override void Apply(PlayerController playerController) {
        for(int i = 0;i< cardsDrawn[level]; i++) {
            playerController.hand.Add();
        }
    }
}
