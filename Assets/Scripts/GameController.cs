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

        foreach(PlayerController p in GetPlayersList()) {
            for(int i = 0; i < 5; i++) {
                p.hand.Add(CardsController.instance.Draw());
            }
        }
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

        currentPlayer.SelectCard(new WorkerCard("Bob budowniczy", "BOB"));
        currentPlayer.PlaySelectedCard(Zone.Chimera);
    }


    public void EndTurn() {

    }

    public List<PlayerController> GetPlayersList() {
        return players.ToList();
    }
}
