using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public List<OtherPlayerUI> otherPlayersUIs;

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
