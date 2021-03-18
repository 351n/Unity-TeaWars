using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string nickname;
    public uint Gold { get => gold; private set => gold = value; }
    public List<Card> hand = new List<Card>();
    public Region region;
    //public PlantCard plant = new PlantCard("Marihuaeh", "PLT");
    //public PlantatorCard plantator = new PlantatorCard("Heniek Rolnik", "PNT");

    public RegionGameObject regionGameObject;
    public PlayerUI ui;

    private uint gold;
    private Card selectedCard;
    private Zone selectedZone;



    void Start() {
        regionGameObject.UpdateUI();
        ui.UpdateHand(hand);
    }

    internal void ApplyPlantEffect() {
        Debug.Log($"Applying {region.plant}");
        region.plant.Apply(this);
    }

    internal void ApplyPlantatorEffect() {
        Debug.Log($"Applying {region.plantator}");
        region.plantator.Apply(this);
        ui.UpdateHand(hand);
    }

    internal void SelectCard(Card card) {
        selectedCard = card;

        region.UnlockAssetZonesSelection();

        Debug.Log($"{nickname} selected {selectedCard}");
    }


    public void SelectAssetZone(Zone zone) {
        selectedZone = zone;

        Debug.Log($"{nickname} selected {selectedZone}");

        ui.ShowConfirmButton();
    }

    public void PlaySelectedCard() {
        if(selectedCard is WorkerCard) {
            PlayCard(selectedCard as WorkerCard, selectedZone);
        } else if(selectedCard is AssetCard) {
            PlayCard(selectedCard as AssetCard, selectedZone);
        }

        hand.Remove(selectedCard);
        ui.UpdateHand(hand);

        ui.HideConfirmButton();
        regionGameObject.region.LockAssetZonesSelection();
        ResetSelection();
    }

    private void ResetSelection() {
        selectedCard = null;
        selectedZone = Zone.None;
    }

    internal void PlayCard(Card card, Zone zone) {
        region.PlayCard(card, zone);
    }

    public void AddGold(uint value) {
        if(uint.MaxValue - value < gold) {
            gold = uint.MaxValue;
        } else {
            gold += value;
        }
    }

    public void SubstractGold(uint value) {
        if(value >= gold) {
            gold = 0;
        } else {
            gold -= value;
        }
    }
}
