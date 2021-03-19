using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkerUI : MonoBehaviour
{
    public Region region;
    public Zone zone;

    public bool isSelectable = false;

    public TextMeshProUGUI nameText;
    public Sprite image;
    public TextMeshProUGUI effectText;
    public WorkerCard card;
    public GameObject border;

    public void SelectThisWorkerZone() {
        if(isSelectable)
            region.SelectWorkerZone(zone);
    }

    internal void UpdateUI(WorkerCard card) {
        if(card != null) {
            isSelectable = false;
            this.card = card;
            nameText.text = card.displayName;
            effectText.text = $"THIS IS WORKER";
        } else {
            nameText.text = "";
            effectText.text = $"";
        }
    }

    public void UnlockSelection() {
        isSelectable = true;
        border.SetActive(true);
    }

    internal void LockSelection() {
        isSelectable = false;
        border.SetActive(false);
    }
}
