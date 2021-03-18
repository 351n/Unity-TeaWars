using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RegionTests
{
    [Test]
    public void RegionBuildAsset() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        AssetCard card = new AssetCard("Test Asset Card", "TST");

        region.PlayCard(card, Zone.Cerber);
    }

    [Test]
    public void RegionBuildAssetFieldOccupy() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        AssetCard card = new AssetCard("Test Asset Card", "TST");

        region.PlayCard(card, Zone.Cerber);
        List<Zone> emptyAssetsZones = region.GetEmptyAssetsFields();

        Assert.IsFalse(emptyAssetsZones.Contains(Zone.Cerber));
    }

    [Test]
    public void RegionBuildAssetOnSameField() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        AssetCard card = new AssetCard("Test Asset Card", "TST");
        AssetCard otherCard = new AssetCard("Other Asset Card", "TST");

        region.PlayCard(card, Zone.Cerber);
        region.PlayCard(otherCard, Zone.Cerber);

        Assert.AreEqual(card, region.GetAsset(Zone.Cerber));
    }

    [Test]
    public void RegionBuildWorker() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        WorkerCard card = new WorkerCard("Test Worker Card", "TST");

        region.PlayCard(card, Zone.Cerber);
    }

    [Test]
    public void RegionBuildWorkerFieldOccupy() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        WorkerCard card = new WorkerCard("Test Worker Card", "TST");

        region.PlayCard(card, Zone.Cerber);
        List<Zone> emptyWorkersZones = region.GetEmptyAssetsFields();

        Assert.IsFalse(emptyWorkersZones.Contains(Zone.Cerber));
    }

    [Test]
    public void RegionBuildWorkerOnSameField() {
        PlayerController player = new PlayerController();
        Region region = new Region(player);
        WorkerCard card = new WorkerCard("Test Worker Card", "TST");
        WorkerCard otherCard = new WorkerCard("Other Worker Card", "TST");

        region.PlayCard(card, Zone.Cerber);
        region.PlayCard(otherCard, Zone.Cerber);

        Assert.AreEqual(card, region.GetWorker(Zone.Cerber));
    }
}
