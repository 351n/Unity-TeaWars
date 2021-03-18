using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject handGameObject;

    public void UpdateHand(List<Card> hand) {
        ClearHand();
        foreach(Card c in hand) {
            var newCard = Instantiate(cardPrefab, handGameObject.transform);
            CardGameObject cgo = newCard.GetComponent<CardGameObject>();
            cgo.UpdateUI(c);
        }
    }

    public void ClearHand() {
        foreach(Transform t in handGameObject.transform) {
            GameObject.Destroy(t.gameObject);
        }
    }
}
