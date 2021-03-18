using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionGameObject : MonoBehaviour
{
    public CardGameObject plantatorCard;
    public CardGameObject plantCard;

    internal void UpdateUI(PlantatorCard plantator, PlantCard plant) {
        plantatorCard.UpdateUI(plantator);
        plantCard.UpdateUI(plant);
    }

    internal void ShowEmptyWorkerFields(Region region) {
        Debug.Log(region);
        var empty = region.GetEmptyWorkerFields();
        foreach(Zone z in empty) {
            Debug.Log(z);
        }
    }
}
