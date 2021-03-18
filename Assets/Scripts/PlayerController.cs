using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string nickname;
    private uint gold;
    public PlantCard plant = new PlantCard("Marihuaeh", "PLT");
    public PlantatorCard plantator = new PlantatorCard("Heniek Rolnik", "PNT");
    public List<Card> hand = new List<Card>();
    public Region region;

    public RegionGameObject regionGameObject;
    public PlayerUI ui;

    private Card selectedCard;

    public uint Gold { get => gold; private set => gold = value; }

    void Start() {
        regionGameObject.UpdateUI(plantator, plant);
        ui.UpdateHand(hand);
    }

    internal void ApplyPlantEffect() {
        Debug.Log($"Applying {plant}");
        plant.Apply(this);
    }

    internal void ApplyPlantatorEffect() {
        Debug.Log($"Applying {plantator}");
        plantator.Apply(this);
        ui.UpdateHand(hand);
    }

    internal void SelectCard(WorkerCard card) {
        selectedCard = card;
    }

    internal void PlaySelectedCard(Zone zone) {
        if(selectedCard is WorkerCard)
            PlayCard(selectedCard as WorkerCard, zone);
    }

    internal void PlayCard(WorkerCard card, Zone zone) {
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
