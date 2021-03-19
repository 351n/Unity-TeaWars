using UnityEngine;
using TMPro;
using System;

public class RegionCardUI : CardGameObject
{
    public Region region;
    public Zone zone;
    public ZoneType type;

    public bool isSelectable = false;

    public void SelectThisCardZone() {
        if(isSelectable && type == ZoneType.Asset) {
            region.SelectAssetZone(zone);
        } else if (isSelectable && type == ZoneType.Worker) {
            region.SelectWorkerZone(zone);
        }
    }

    public void UnlockSelection() {
        isSelectable = true;
        border.SetActive(true);
    }

    internal void LockSelection() {
        isSelectable = false;
        border.SetActive(false);
    }
}

public enum ZoneType { Asset, Worker, Plant, Plantator, None }
