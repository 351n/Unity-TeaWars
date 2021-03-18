using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCard : Card
{
    uint upgradeLevel = 0;
    readonly uint[] upgradeCost = { 4, 4 };
    readonly uint[] profit = { 2, 3, 4 };

    public PlantCard(string displayName, string id) : base(displayName, id) {
    }

    public void Upgrade(PlayerController playerController) {
        if(playerController.Gold >= GetUpgradeCost()) {
            if(upgradeLevel < upgradeCost.Length) {
                playerController.SubstractGold(GetUpgradeCost());
                upgradeLevel++;
            }
        }
    }

    public uint GetUpgradeCost() {
        if(upgradeLevel < upgradeCost.Length - 1) {
            return upgradeCost[upgradeLevel];
        } else {
            return 0;
        }
    }

    public uint GetProfitValue() {
        return profit[upgradeLevel];
    }

    public override void Apply(PlayerController playerController) {
        playerController.AddGold(profit[upgradeLevel]);
    }

    public override string ToString() {
        string result = base.ToString();
        result += $" G:{profit[upgradeLevel]}";

        return result;
    }
}
