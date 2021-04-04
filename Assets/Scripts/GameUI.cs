using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public List<OtherPlayerUI> otherPlayersUIs;
    public PlayerUI playerUI;
    public RegionGameObject rgo;
    public TextMeshProUGUI currPlayerText;

    internal void UnlockPlayerSelection() {
        foreach(OtherPlayerUI p in otherPlayersUIs) {
            p.UnlockSelection();
        }
    }

    internal void LockPlayerSelection() {
        foreach(OtherPlayerUI p in otherPlayersUIs) {
            p.LockSelection();
        }
    }
}
