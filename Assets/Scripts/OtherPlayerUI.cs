using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OtherPlayerUI : MonoBehaviour
{

    public PlayerController player;

    public GameObject selectObject;
    public TextMeshProUGUI playerText;

    public bool isSelectable = false;

    public void SelectThisPlayer() {
        if(isSelectable) {
            GameController.instance.SelectPlayer(player);
        }
    }

    public void UnlockSelection() {
        isSelectable = true;
        if(selectObject)
            selectObject.SetActive(true);
    }

    internal void LockSelection() {
        isSelectable = false;
        if(selectObject)
            selectObject.SetActive(false);
    }

    internal void AssingPlayer(PlayerController p) {
        player = p;
        playerText.text = p.nickname;
    }
}
