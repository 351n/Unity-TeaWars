using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

#pragma warning disable UNT0010 // Component instance creation
public class CardsTests
{
    [Test]
    public void PlantProfitTest() {
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 2;

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }

    [Test]
    public void PlantUpgradedProfitTest() {
        PlayerController player = new PlayerController();
        player.AddGold(1337);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 3;

        card.Upgrade(player);

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }

    [Test]
    public void PlantTwiceUpgradedProfitTest() {
        PlayerController player = new PlayerController();
        player.AddGold(1337);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 4;

        card.Upgrade(player);
        card.Upgrade(player);

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }

    [Test]
    public void PlantTriceUpgradedProfitTest() {
        PlayerController player = new PlayerController();
        player.AddGold(1337);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 4;

        card.Upgrade(player);
        card.Upgrade(player);
        card.Upgrade(player);

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }

    [Test]
    public void PlantUpgradeNoMoneyTest() {
        PlayerController player = new PlayerController();
        player.AddGold(2);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 2;

        card.Upgrade(player);

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }

    [Test]
    public void PlantUpgradeTwiceNoMoneyTest() {
        PlayerController player = new PlayerController();
        player.AddGold(5);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expected = 4;

        card.Upgrade(player);
        card.Upgrade(player);
        card.Upgrade(player);

        Assert.AreEqual(expected, card.GetUpgradeCost());
    }
}
#pragma warning restore UNT0010 // Component instance creation