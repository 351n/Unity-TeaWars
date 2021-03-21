using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject handGameObject;
    public List<CardGameObject> handCards = new List<CardGameObject>();
    public GameObject confirmButton;

    public void UpdateHand(List<Card> hand) {
        ClearHand();
        foreach(Card c in hand) {
            var newCard = Instantiate(cardPrefab, handGameObject.transform);
            CardGameObject cgo = newCard.GetComponent<CardGameObject>();
            cgo.UpdateUI(c);
            handCards.Add(cgo);
        }
    }

    public void ClearHand() {
        foreach(Transform t in handGameObject.transform) {
            handCards.Remove(t.gameObject.GetComponent<CardGameObject>());
            GameObject.Destroy(t.gameObject);
        }
    }

    public void GrayOutAllCards() {
        foreach(CardGameObject cgo in handCards) {
            cgo.GrayOut();
        }
    }

    public void GrayOutAssetCards() {
        foreach(CardGameObject cgo in handCards) {
            if(cgo.card is AssetCard) {
                cgo.GrayOut();
            }
        }
    }

    public void GrayOutWorkerCards() {
        foreach(CardGameObject cgo in handCards) {
            if(cgo.card is WorkerCard) {
                cgo.GrayOut();
            }
        }
    }

    public void GrayOutTrickeryCards() {
        foreach(CardGameObject cgo in handCards) {
            if(cgo.card is TrickeryCard) {
                cgo.GrayOut();
            }
        }
    }

    internal void ShowConfirmButton() {
        confirmButton.SetActive(true);
    }

    internal void HideConfirmButton() {
        confirmButton.SetActive(false);
    }
}
