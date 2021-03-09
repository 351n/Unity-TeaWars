using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Queue<PlayerController> players;
    PlayerController currentPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartTurn() {
        PlagueCard plague = GetPlagueCard();
        plague.Apply();
        if(plague.effect.skippedTurns <= 0) {
            currentPlayer.ApplyPlantEffect();
            currentPlayer.ApplyPlantatorEffect();
        }
    }


    public void EndTurn() {

    }

    private PlagueCard GetPlagueCard() {
        throw new NotImplementedException();
    }
}
