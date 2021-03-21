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

    public PlayerUI ui;

    private uint gold;
    private Card selectedCard;
    private Zone selectedZone;
    private PlayerController selectedTarget;

    bool playedAssetCard = false;
    bool playedWorkerCard = false;
    bool playedTrickeryCard = false;

    bool canPlayTwoCards = true;

    void Start() {
        region.UpdateUI();
        ui.UpdateHand(hand);
    }

    internal void ApplyPlantEffect() {
        region.ApplyPlantEffect();
    }

    internal void ApplyPlantatorEffect() {
        region.ApplyPlantatorEffect();
        ui.UpdateHand(hand);
    }

    public void SelectCard(Card card) {
        if(selectedCard != null) {
            region.LockAssetZonesSelection();
            region.LockWorkersZonesSelection();
        }

        selectedCard = card;

        if(card is AssetCard) {
            if(CanPlayAssetCard()) {
                region.UnlockAssetZonesSelection();
            } else {
                Debug.Log("Cannot play this asset card");
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
                    //selection of player
                } else if(t.Target == Target.Building) {
                    //selection of player and building
                }
            } else {
                Debug.Log("Cannot play this trickery card");
            }
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
        selectedZone = Zone.None;
    }

    public void PlaySelectedCard() {
        if(selectedCard is WorkerCard && CanPlayWorkerCard()) {
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
        } else if(selectedCard is AssetCard && CanPlayAssetCard()) {
            PlayCard(selectedCard as AssetCard, selectedZone);

            if(!playedAssetCard) {
                playedAssetCard = true;
            } else {
                LockPlayingCards();
            }
        } else if(selectedCard is TrickeryCard && CanPlayTrickeryCard()) {
            PlayCard(selectedCard as TrickeryCard, selectedTarget);

            if(!playedAssetCard) {
                playedTrickeryCard = true;
            } else {
                LockPlayingCards();
            }
        }

        UpdateCardsPermissions();
    }

    private bool CanPlayTrickeryCard() {
        return (!playedTrickeryCard || canPlayTwoCards);
    }

    private bool CanPlayAssetCard() {
        return (!playedAssetCard || canPlayTwoCards);
    }

    private bool CanPlayWorkerCard() {
        return (!playedWorkerCard || canPlayTwoCards);
    }

    public bool UpdateCardsPermissions() {
        if(canPlayTwoCards) {
            bool a = playedAssetCard;
            bool b = playedWorkerCard;
            bool c = playedTrickeryCard;

            //check if zero or only one card of any type was played
            canPlayTwoCards = ((!a && !b && !c) || (!a && !b && c) || (!a && b && !c) || (a && !b && !c));

            if(!canPlayTwoCards) {
                LockPlayingCards();
            }
        }

        return canPlayTwoCards;
    }

    private void LockPlayingCards() {
        playedAssetCard = true;
        playedWorkerCard = true;
        playedTrickeryCard = true;
        canPlayTwoCards = false;
    }

    internal void PlayCard(Card card, Zone zone) {
        if(card is AssetCard || card is WorkerCard) {
            region.PlayCard(card, zone);
        }

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
        throw new NotImplementedException();
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
}
