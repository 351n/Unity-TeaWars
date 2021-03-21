using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardGameObject : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Sprite image;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI effectText;
    public Image background;
    public GameObject border;
    public Card card;

    public void UpdateUI(Card card) {
        this.card = card;

        if(card != null) {
            nameText.text = card.displayName;

            if(card is PlantatorCard) {
                PlantatorCard p = card as PlantatorCard;
                effectText.text = $"{p.GetEffectString()}";
                if(costText) {
                    costText.text = $"";
                }
            } else if(card is PlantCard) {
                PlantCard p = card as PlantCard;
                effectText.text = $"G: {p.GetProfitValue()}";
                if(costText) {
                    costText.text = $"";
                }
            } else if(card is AssetCard) {
                AssetCard p = card as AssetCard;
                effectText.text = $"This is Asset";
                if(costText) {
                    costText.text = $"-{p.playCost}G";
                }
            } else if(card is WorkerCard) {
                WorkerCard p = card as WorkerCard;
                effectText.text = $"This is Worker";
                if(costText) {
                    costText.text = $"-{p.HireCost}G";
                }
            } else if(card is TrickeryCard) {
                TrickeryCard p = card as TrickeryCard;
                effectText.text = $"This is Trickery";
                if(costText) {
                    costText.text = $"";
                }
            }
        } else {
            nameText.text = "";
            effectText.text = $"";
            if(costText) {
                costText.text = $"";
            }
        }
    }

    public void GrayOut() {
        background.color = Color.gray;
    }

    public void ChangeBackgroundToDefault() {
        background.color = Color.white;
    }
}
