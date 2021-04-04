using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int HAND_MAX_ITEMS = 10;

    public string nickname;
    public uint Gold { get => gold; private set => gold = value; }
    public Region region;

    public PlayerUI ui;
    public CardsController cardsController;

    private List<Card> hand = new List<Card>();
    private uint gold;
    private Card selectedCard;
    private Zone selectedZone;
    private PlayerController selectedTarget;

    bool playedAssetCard = false;
    bool playedWorkerCard = false;
    bool playedTrickeryCard = false;

    bool canPlayTwoCards = true;


    public PlayerController() {
        this.region = new Region(this);
    }

    public PlayerController(CardsController cardsController, uint Gold = 0) {
        this.region = new Region(this);
        this.cardsController = cardsController;
        this.gold = Gold;
    }

    public PlayerController(Region region, CardsController cardsController, uint Gold = 0) {
        this.region = region;
        this.cardsController = cardsController;
        this.gold = Gold;
    }

    void Start() {
        region.UpdateUI();

        if(ui)
            ui.UpdateHand(hand);
    }

    internal void ApplyPlantEffect() {
        region.ApplyPlantEffect();
    }

    internal void ApplyPlantatorEffect() {
        region.ApplyPlantatorEffect();

        if(ui)
            ui.UpdateHand(hand);
    }

    public void AddToHand(Card card) {
        if(hand.Count < HAND_MAX_ITEMS)
            hand.Add(card);
    }

    public void AddToHand(List<Card> cards) {
        foreach(Card c in cards) {
            AddToHand(c);
        }
    }

    public void SelectCard(Card card) {
        if(selectedCard != null) {
            region.LockAssetZonesSelection();
            region.LockWorkersZonesSelection();
            GameController.instance.LockPlayerSelection();
        }

        selectedCard = card;

        if(card is AssetCard) {
            if(CanPlayAssetCard()) {
                region.UnlockAssetZonesSelection();
            } else {
                Debug.Log($"Cannot play this asset card {canPlayTwoCards}");
            }
        } else if(card is WorkerCard) {
            WorkerCard w = card as WorkerCard;
            if(CanPlayWorkerCard()) {
                region.UnlockWorkerZonesSelection();
            } else {
                Debug.Log("Cannot play this worker card");
            }
        } else if(card is TrickeryCard) {
            if(CanPlayTrickeryCard()) {
                TrickeryCard t = card as TrickeryCard;
                if(t.Target == Target.Player) {
                    GameController.instance.UnlockPlayerSelection();
                } else if(t.Target == Target.Building) {
                    //selection of player and building
                }
            } else {
                Debug.Log("Cannot play this trickery card");
            }
        }
    }

    internal void SelectPlayer(PlayerController player) {
        selectedTarget = player;

        if(ui) {
            ui.ShowConfirmButton();
        }
    }

    public void SelectAssetZone(Zone zone) {
        selectedZone = zone;

        if(ui) {
            ui.ShowConfirmButton();
        }
    }

    public void SelectWorkerZone(Zone zone) {
        selectedZone = zone;

        if(ui) {
            ui.ShowConfirmButton();
        }
    }

    private void ResetSelection() {
        selectedCard = null;
        selectedTarget = null;
        selectedZone = Zone.None;

        UpdateCardsPermissions();
    }

    public void PlaySelectedCard() {
        if(selectedCard is AssetCard && CanPlayAssetCard()) {
            AssetCard a = selectedCard as AssetCard;

            if(a.playCost <= Gold) {
                SubstractGold(a.playCost);
                PlayCard(selectedCard as AssetCard, selectedZone);

                if(!playedAssetCard) {
                    playedAssetCard = true;
                } else {
                    LockPlayingCards();
                }
            }
        } else if(selectedCard is WorkerCard && CanPlayWorkerCard()) {
            WorkerCard w = selectedCard as WorkerCard;

            if(w.HireCost <= Gold) {
                SubstractGold(w.HireCost);
                PlayCard(selectedCard as WorkerCard, selectedZone);

                if(!playedWorkerCard) {
                    playedWorkerCard = true;
                } else {
                    LockPlayingCards();
                }
            }
        } else if(selectedCard is TrickeryCard && CanPlayTrickeryCard()) {
            PlayCard(selectedCard as TrickeryCard, selectedTarget);

            if(!playedTrickeryCard) {
                playedTrickeryCard = true;
            } else {
                LockPlayingCards();
            }
        }

        UpdateRegionUI();
        UpdateCardsPermissions();
    }


    private bool CanPlayAssetCard() {
        return (!playedAssetCard || canPlayTwoCards);
    }

    private bool CanPlayWorkerCard() {
        return (!playedWorkerCard || canPlayTwoCards);
    }

    private bool CanPlayTrickeryCard() {
        return (!playedTrickeryCard || canPlayTwoCards);
    }

    public bool UpdateCardsPermissions() {
        if(canPlayTwoCards) {
            bool a = playedAssetCard;
            bool b = playedWorkerCard;
            bool c = playedTrickeryCard;

            //check if zero or only one card of any type was played
            if(!a && !b && !c) {
                canPlayTwoCards = true;
            } else if(!a && !b && c) {
                canPlayTwoCards = true;
            } else if(!a && b && !c) {
                canPlayTwoCards = true;
            } else if(a && !b && !c) {
                canPlayTwoCards = true;
            } else {
                canPlayTwoCards = false;
            }
        }

        if(!canPlayTwoCards && ui) {
            Debug.Log("here");
            if(playedAssetCard) {
                ui.GrayOutAssetCards();
            }

            if(playedWorkerCard) {
                ui.GrayOutWorkerCards();
            }

            if(playedTrickeryCard) {
                ui.GrayOutTrickeryCards();
            }
        }

        return canPlayTwoCards;
    }

    private void LockPlayingCards() {
        playedAssetCard = true;
        playedWorkerCard = true;
        playedTrickeryCard = true;
        canPlayTwoCards = false;

        if(ui) {
            ui.GrayOutAllCards();
        }
    }

    internal void PlayCard(Card card, Zone zone) {
        if(card is AssetCard || card is WorkerCard) {
            region.PlayCard(card, zone);
        }

        cardsController.Discard(selectedCard);
        hand.Remove(selectedCard);

        if(ui) {
            ui.UpdateHand(hand);
            ui.HideConfirmButton();
        }

        region.LockAssetZonesSelection();
        region.LockWorkersZonesSelection();
        ResetSelection();
    }

    internal void PlayCard(TrickeryCard card, PlayerController target) {
        Debug.Log($"{name} used trickery on {target}");

        hand.Remove(card);

        if(ui) {
            ui.UpdateHand(hand);
            ui.HideConfirmButton();
        }

        GameController.instance.ui.LockPlayerSelection();
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

    internal void UpdateRegionUI() {
        if(region)
            region.UpdateUI();
    }

    internal void AssingUI(PlayerUI playerUI, RegionGameObject regionGameObject) {
        ui = playerUI;
        region.ui = regionGameObject;
        region.ui.region = region;
    }

    internal void RevokeUI() {
        ResetSelection();
        ui.HideConfirmButton();
        region.LockAssetZonesSelection();
        region.LockWorkersZonesSelection();
        GameController.instance.ui.LockPlayerSelection();

        ui = null;
        region.ui = null;
    }
}
