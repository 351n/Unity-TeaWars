using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCard : Card
{
    int upgradeLevel = 0;
    int[] upgradeCost = { 4, 4 };
    int[] profit = { 2, 3, 4 };

    public void Upgrade() {
        if(upgradeLevel < upgradeCost.Length - 1) {
            upgradeLevel++;
        }
    }

    public int GetUpgradeCost() {
        if(upgradeLevel == upgradeCost.Length - 1)
            return -1;

        return upgradeCost[upgradeLevel];
    }

    public override void Apply() {
        throw new System.NotImplementedException();
    }

    public override void Apply(PlayerController playerController) {
        playerController.gold += profit[upgradeLevel]; 
    }
}
