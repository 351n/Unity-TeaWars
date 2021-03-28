using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegionGameObject : MonoBehaviour
{
    public Region region;
    public CardGameObject plantatorCard;
    public CardGameObject plantCard;

    public List<RegionCardUI> assets;
    public List<RegionCardUI> workers;

    public TextMeshProUGUI goldText;

    internal void UpdateUI() {
        if(!region.isInitialized) { region.InitializeFields(); }
        plantatorCard.UpdateUI(region.plantator);
        plantCard.UpdateUI(region.plant);

        for(int i = 0; i < assets.Count; i++) {
            assets[i].UpdateUI(region.GetAsset((Zone)i));
        }

        for(int i = 0; i < workers.Count; i++) {
            workers[i].UpdateUI(region.GetWorker((Zone)i));
        }

        if(goldText) {
            goldText.text = $"{region.owner.Gold}";
        }
    }

    internal void ShowEmptyWorkerFields(Region region) {
        Debug.Log(region);
        var empty = region.GetEmptyWorkerFields();
        foreach(Zone z in empty) {
            Debug.Log(z);
        }
    }
}
