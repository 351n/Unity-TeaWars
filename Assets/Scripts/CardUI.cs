using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardUI : CardGameObject
{
    public void SelectThisCard() {
        GameController.instance.currentPlayer.SelectCard(card);
    }
}
