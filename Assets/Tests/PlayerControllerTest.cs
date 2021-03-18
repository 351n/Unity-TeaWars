using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTest
{
    [Test]
    public void AddGold() {
        PlayerController player = new PlayerController();
        uint expected = 10;

        player.AddGold(10);

        Assert.AreEqual(expected, player.Gold);
    }

    [Test]
    public void AddGoldLimit() {
        PlayerController player = new PlayerController();
        uint expected = uint.MaxValue;

        player.AddGold(uint.MaxValue - 1);
        player.AddGold(1337);

        Assert.AreEqual(expected, player.Gold);
    }

    [Test]
    public void SubstracktGold() {
        PlayerController player = new PlayerController();
        uint expected = 90;

        player.AddGold(100);
        player.SubstractGold(10);

        Assert.AreEqual(expected, player.Gold);
    }

    [Test]
    public void SubstracktGoldLimit() {
        PlayerController player = new PlayerController();
        uint expected = 0;

        player.SubstractGold(1337);

        Assert.AreEqual(expected, player.Gold);
    }

    [Test]
    public void PlantCardEffect() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        player.region = region;
        PlantCard plant = new PlantCard("Test Plant", "TST");
        player.region.plant = plant;
        uint expectedGold = plant.GetProfitValue();

        plant.Apply(player);

        Assert.AreEqual(expectedGold,player.Gold);
    }

    [Test]
    public void PlantCardUpgradedEffect() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        player.region = region;
        PlantCard plant = new PlantCard("Test Plant", "TST");

        player.AddGold(plant.GetUpgradeCost());
        player.region.plant = plant;
        plant.Upgrade(player);
        uint expectedGold = plant.GetProfitValue();

        plant.Apply(player);

        Assert.AreEqual(expectedGold, player.Gold);
    }
}
