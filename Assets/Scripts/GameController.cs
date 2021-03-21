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

    Queue<PlayerController> players;
    public PlayerController currentPlayer;

    void Start() {
        Initialize();
        StartTurn();
    }

    private void Initialize() {
        players = new Queue<PlayerController>(FindObjectsOfType<PlayerController>().ToList());
        currentPlayer = players.Peek();
        //TODO remove this after testing
        currentPlayer.AddGold(100);

        foreach(PlayerController p in GetPlayersList()) {
            for(int i = 0; i < 5; i++) {
                p.hand.Add(CardsController.instance.Draw());
            }
        }
    }

    public void StartTurn() {
        PlagueCard plague = CardsController.instance.GetPlagueCard();
        plague.Apply(GetPlayersList());
        CardsController.instance.Discard(plague);

        if(plague.effect.skippedTurns <= 0) {
            currentPlayer.ApplyPlantEffect();
            currentPlayer.ApplyPlantatorEffect();
        } else {
            //Skip
        }
    }

    public void EndTurn() {
        //Give control to next player
    }

    public List<PlayerController> GetPlayersList() {
        return players.ToList();
    }

    internal void UpdateRegionUI() {
        currentPlayer.UpdateRegionUI();
    }
}
