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

    public Effect(int gold = 0, int cardDraw = 0, int sabotage = 0, int theft = 0, int skippedTurns = 0) {
        this.gold = gold;
        this.cardDraw = cardDraw;
        this.sabotage = sabotage;
        this.theft = theft;
        this.skippedTurns = skippedTurns;
    }

    public override string ToString() {
        string result = "(";

        if(gold != 0) {
            result += $"G: {gold},";
        }

        if(cardDraw != 0) {
            result += $"D: {cardDraw},";
        }

        if(sabotage != 0) {
            result += $"S: {sabotage},";
        }

        if(theft != 0) {
            result += $"U: {theft},";
        }

        if(skippedTurns != 0) {
            result += $"sk: {skippedTurns}";
        }

        if(result.EndsWith(",")) {
            result = result.TrimEnd(',');
        }

        return result + ")";
    }
}