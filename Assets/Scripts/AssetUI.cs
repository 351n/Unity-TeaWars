using UnityEngine;
using TMPro;
using System;

public class AssetUI : MonoBehaviour
{
    public Region region;
    public Zone zone;

    public bool isSelectable = false;

    public TextMeshProUGUI nameText;
    public Sprite image;
    public TextMeshProUGUI effectText;
    public AssetCard card;
    public GameObject border;

    public void SelectThisAssetZone() {
        if(isSelectable)
            region.SelectAssetZone(zone);
    }

    internal void UpdateUI(AssetCard card) {
        if(card != null) {
            isSelectable = false;
            this.card = card;
            nameText.text = card.displayName;
            effectText.text = $"THIS IS ASSET";
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
