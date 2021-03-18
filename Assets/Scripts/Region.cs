using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public PlayerController owner;
    List<WorkerCard> workers = new List<WorkerCard>(4){ null, null, null, null };
    List<AssetCard> assets = new List<AssetCard>(4){ null, null, null, null };

    public Region(PlayerController owner) {
        this.owner = owner;
        InitializeFields();
    }

    private void InitializeFields() {
        workers = new List<WorkerCard>(4) { null, null, null, null };
        assets = new List<AssetCard>(4) { null, null, null, null };
    }

    public void PlayCard(WorkerCard card, Zone zone) {
        if(workers == null) {
            InitializeFields();
        }

        if(workers[(int)zone] == null) {
            workers.Insert((int)zone, card);
        }
    }

    public void PlayCard(AssetCard card, Zone zone) {
        Debug.Log(assets.Count);
        if(assets[(int)zone] == null) {
            assets.Insert((int)zone, card);
        }
    }

    public WorkerCard GetWorker(Zone zone) {
        return workers[(int)zone];
    }

    public AssetCard GetAsset(Zone zone) {
        return assets[(int)zone];
    }

    public List<Zone> GetEmptyWorkerFields() {
        List<Zone> result = new List<Zone>();
        for(int i = 0; i < 4; i++) {
            if(i > workers.Count && workers[i] == null) {
                result.Add((Zone)i);
            }
        }
        return result;
    }

    public List<Zone> GetEmptyAssetsFields() {
        List<Zone> result = new List<Zone>();
        for(int i = 0; i < 4; i++) {
            if(i > assets.Count && assets[i] == null) {
                result.Add((Zone)i);
            }
        }
        return result;
    }
}

public enum Zone { Chimera, Cerber, Hydra, Gorgon }