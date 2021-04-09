using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController instance;

    void Awake() {
        instance = this;
    }

    #endregion

    public const int HAND_START_ITEMS = 5;
    public const int START_GOLD = 50;

    Queue<PlayerController> players;

    public PlayerController currentPlayer;
    public GameUI ui;

    void Start() {
        Initialize();
        StartTurn();
    }

    private void Initialize() {
        players = new Queue<PlayerController>(FindObjectsOfType<PlayerController>().ToList());
        currentPlayer = players.Dequeue();
        ui.currPlayerText.text = currentPlayer.nickname;
        Debug.Log($"Current {currentPlayer.nickname}");
        players.Enqueue(currentPlayer);

        foreach(PlayerController p in GetPlayersList()) {
            p.AddGold(START_GOLD);
            p.DrawToHand(HAND_START_ITEMS);
        }
    }

    private void AssignPlayersUIs() {
        currentPlayer.AssingUI(ui.playerUI, ui.rgo);

        foreach(OtherPlayerUI u in ui.otherPlayersUIs) {
            u.player = null;
        }

        foreach(PlayerController p in GetPlayersList()) {
            if(p != currentPlayer) {
                foreach(OtherPlayerUI u in ui.otherPlayersUIs) {
                    if(u.player is null) {
                        u.AssingPlayer(p);
                        break;
                    }
                }
            }
        }
    }

    public void StartTurn() {
        AssignPlayersUIs();
        currentPlayer.UpdateRegionUI();

        PlagueCard plague = CardsController.instance.GetPlagueCard();
        plague.Apply(GetPlayersList());
        CardsController.instance.Discard(plague);
        currentPlayer.UpdateRegionUI();

        if(plague.effect.skippedTurns <= 0) {
            currentPlayer.ApplyPlantEffect();
            currentPlayer.UpdateRegionUI();
            currentPlayer.ApplyPlantatorEffect();
            currentPlayer.UpdateRegionUI();
        } else {
            EndTurn();
        }
    }

    public void EndTurn() {
        currentPlayer.RevokeUI();
        Debug.Log("Ending turn");
        currentPlayer = players.Dequeue();
        players.Enqueue(currentPlayer);
        ui.currPlayerText.text = currentPlayer.nickname;
        Debug.Log($"{currentPlayer.nickname} gets control");

        StartTurn();
    }

    public List<PlayerController> GetPlayersList() {
        return players.ToList();
    }

    internal void UpdateRegionUI() {
        currentPlayer.UpdateRegionUI();
    }

    internal void UnlockPlayerSelection() {
        ui.UnlockPlayerSelection();
    }

    internal void LockPlayerSelection() {
        ui.LockPlayerSelection();
    }

    internal void SelectPlayer(PlayerController player) {
        currentPlayer.SelectPlayer(player);
    }

    public void PlaySelectedCard() {
        currentPlayer.PlaySelectedCard();
    }
}
