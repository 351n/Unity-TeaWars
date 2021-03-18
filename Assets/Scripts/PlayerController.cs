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

    bool playedAssetCard = false;
    bool playedWorkerCard = false;
    bool playedTrickeryCard = false;

    bool canPlayTwoCards = true;

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

    public void SelectCard(Card card) {
        selectedCard = card;

        region.UnlockAssetZonesSelection();

        Debug.Log($"{nickname} selected {selectedCard}");
    }


    public void SelectAssetZone(Zone zone) {
        selectedZone = zone;

        Debug.Log($"{nickname} selected {selectedZone}");

        if(ui) {
            ui.ShowConfirmButton();
        }
    }

    public void PlaySelectedCard() {
        if(selectedCard is WorkerCard && (!playedWorkerCard || canPlayTwoCards)) {
            PlayCard(selectedCard as WorkerCard, selectedZone);

            if(!playedWorkerCard) {
                playedWorkerCard = true;
            } else {
                canPlayTwoCards = false;
            }
        } else if(selectedCard is AssetCard && (!playedAssetCard || canPlayTwoCards)) {
            PlayCard(selectedCard as AssetCard, selectedZone);

            if(!playedAssetCard) {
                playedAssetCard = true;
            } else {
                canPlayTwoCards = false;
            }
        }

        UpdateCardsPermissions();
    }

    public bool UpdateCardsPermissions() {
        if(canPlayTwoCards) {
            bool a = playedAssetCard;
            bool b = playedWorkerCard;
            bool c = playedTrickeryCard;

            //check if zero or only one was played
            canPlayTwoCards = ((!a && !b && !c) || (!a && !b && c) || (!a && b && !c) || (a && !b && !c));
        }

        return canPlayTwoCards;
    }

    internal void UpdateRegionUI() {
        if(regionGameObject)
            regionGameObject.UpdateUI();
    }

    private void ResetSelection() {
        selectedCard = null;
        selectedZone = Zone.None;
    }

    internal void PlayCard(Card card, Zone zone) {
        region.PlayCard(card, zone);

        hand.Remove(selectedCard);

        if(ui) {
            ui.UpdateHand(hand);
            ui.HideConfirmButton();
        }

        region.LockAssetZonesSelection();
        ResetSelection();
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
