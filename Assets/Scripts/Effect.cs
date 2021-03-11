using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    public int gold;
    public int cardDraw;
    public int sabotage;
    public int theft;
    public int skippedTurns;

    public Effect() {
        this.gold = 0;
        this.cardDraw = 0;
        this.sabotage = 0;
        this.theft = 0;
        this.skippedTurns = 0;
    }

    public Effect(int gold, int cardDraw, int sabotage, int theft, int skippedTurns) {
        this.gold = gold;
        this.cardDraw = cardDraw;
        this.sabotage = sabotage;
        this.theft = theft;
        this.skippedTurns = skippedTurns;
    }

    public override string ToString() {
        return $"(G:{gold}, D:{cardDraw}, S:{sabotage}, U:{theft}, sk:{skippedTurns})";
    }
}