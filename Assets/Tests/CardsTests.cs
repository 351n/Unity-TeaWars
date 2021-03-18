using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
    public void PlantTricUpgradedProfitTest() {
        PlayerController player = new PlayerController();
        player.AddGold(1337);
        PlantCard card = new PlantCard("Test Plant Card", "TST");
        int expectedProfit = 4;

        card.Upgrade(player);
        card.Upgrade(player);
        card.Upgrade(player);

        Assert.AreEqual(expectedProfit, card.GetProfitValue());
    }
}
