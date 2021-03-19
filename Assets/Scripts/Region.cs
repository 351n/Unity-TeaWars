using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public RegionGameObject ui;
    public PlayerController owner;
    public PlantCard plant = new PlantCard("Marihuaeh", "PLT");
    public PlantatorCard plantator = new PlantatorCard("Heniek Rolnik", "PNT");
    List<WorkerCard> workers = new List<WorkerCard>(4) { null, null, null, null };
    List<AssetCard> assets = new List<AssetCard>(4) { null, null, null, null };
    private bool canSelectAssetZone = false;
    internal bool isInitialized = false;
    private bool canSelectWorkersZone;

    public Region(PlayerController owner) {
        this.owner = owner;
        InitializeFields();
    }

    public void InitializeFields() {
        plant = new PlantCard("Marihuaeh", "PLT");
        plantator = new PlantatorCard("Heniek Rolnik", "PNT");
        workers = new List<WorkerCard>(4) { null, null, null, null };
        assets = new List<AssetCard>(4) { null, null, null, null };
        isInitialized = true;
    }

    internal void ApplyPlantEffect() {
        plant.Apply(owner);
    }

    internal void ApplyPlantatorEffect() {
        plantator.Apply(owner);
    }

    public void PlayCard(Card card, Zone zone) {
        if(!isInitialized) {
            InitializeFields();
        }

        if(card is WorkerCard) {
            PlayCard(card as WorkerCard, zone);
        } else if(card is AssetCard) {
            PlayCard(card as AssetCard, zone);
        }

        if(ui) { ui.UpdateUI(); }
    }

    private void PlayCard(WorkerCard card, Zone zone) {
        if(workers[(int)zone] == null) {
            workers.Insert((int)zone, card);
        }
    }

    private void PlayCard(AssetCard card, Zone zone) {
        if(assets[(int)zone] == null) {
            assets.Insert((int)zone, card);
        }
    }

    #region AssetsSelection
    internal void UnlockAssetZonesSelection() {
        canSelectAssetZone = true;
        UnlockAssetsZones(GetEmptyAssetsFields());
    }

    private void UnlockAssetsZones(List<Zone> lists) {
        if(ui) {
            foreach(Zone z in lists) {
                ui.assets[(int)z].UnlockSelection();
            }
        }
    }

    internal void LockAssetZonesSelection() {
        canSelectAssetZone = false;
        LockAssetsZones();
    }

    private void LockAssetsZones() {
        if(ui) {
            foreach(AssetUI a in ui.assets) {
                a.LockSelection();
            }
        }
    }

    public void SelectAssetZone(Zone zone) {
        GameController.instance.currentPlayer.SelectAssetZone(zone);
    }

    #endregion

    internal void UnlockWorkerZonesSelection() {
        canSelectWorkersZone = true;
        UnlockWorkersZones(GetEmptyWorkerFields());
    }

    private void UnlockWorkersZones(List<Zone> lists) {
        if(ui) {
            foreach(Zone z in lists) {
                ui.workers[(int)z].UnlockSelection();
            }
        }
    }

    internal void LockWorkersZonesSelection() {
        canSelectAssetZone = false;
        LockWorkersZones();
    }

    private void LockWorkersZones() {
        if(ui) {
            foreach(AssetUI a in ui.assets) {
                a.LockSelection();
            }
        }
    }

    public void SelectWorkerZone(Zone zone) {
        GameController.instance.currentPlayer.SelectWorkerZone(zone);
    }

    public AssetCard GetAsset(Zone zone) {
        return assets[(int)zone];
    }

    public WorkerCard GetWorker(Zone zone) {
        return workers[(int)zone];
    }

    public List<Zone> GetEmptyWorkerFields() {
        List<Zone> result = new List<Zone>();
        for(int i = 0; i < 4; i++) {
            if(i > workers.Count || workers[i] == null) {
                result.Add((Zone)i);
            }
        }
        return result;
    }

    public List<Zone> GetEmptyAssetsFields() {
        List<Zone> result = new List<Zone>();
        for(int i = 0; i < 4; i++) {
            if(i > assets.Count || assets[i] == null) {
                result.Add((Zone)i);
            }
        }

        return result;
    }
}

public enum Zone { Chimera, Cerber, Hydra, Gorgon, None }