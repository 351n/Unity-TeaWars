using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    Queue<PlayerController> players;
    PlayerController currentPlayer;

    void Start() {
        Initialize();
        StartTurn();
    }

    void Update() {

    }

    private void Initialize() {
        players = new Queue<PlayerController>(FindObjectsOfType<PlayerController>().ToList());
        currentPlayer = players.Peek();
    }

    public void StartTurn() {
        Debug.Log("Starting turn");
        Debug.Log("Drawing Plague Card");
        PlagueCard plague = CardsController.instance.GetPlagueCard();
        Debug.Log(plague);

        Debug.Log("Applying Plague Card");
        plague.Apply(GetPlayersList());

        if(plague.effect.skippedTurns <= 0) {
            Debug.Log($"Applying Plant Card for {currentPlayer.nickname}");
            currentPlayer.ApplyPlantEffect();
            Debug.Log($"Applying Plantator Card for {currentPlayer.nickname}");
            currentPlayer.ApplyPlantatorEffect();
        }
    }


    public void EndTurn() {

    }



    public List<PlayerController> GetPlayersList() {
        return players.ToList();
    }
}
