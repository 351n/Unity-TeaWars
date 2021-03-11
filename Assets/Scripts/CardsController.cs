using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour
{
    #region Singleton

    public static CardsController instance;

    void Awake() {
        instance = this;
    }

    #endregion

    Stack<PlagueCard> plagueStack = new Stack<PlagueCard>();
    Stack<Card> cardsStack = new Stack<Card>();

    void Start() {
        plagueStack.Push(new PlagueCard("Plague Card","CRD_PLG_1"));

        cardsStack.Push(new TrickeryCard("Trickery Card", "CRD_TRC_1"));

        cardsStack.Push(new WorkerCard("Worker Card", "CRD_WRK_1"));

        cardsStack.Push(new AssetCard("Asset Card", "CRD_AST_1"));
    }

    public PlagueCard GetPlagueCard() {
        return plagueStack.Peek();
    }

    internal Card Draw() {
       return cardsStack.Peek();
    }
}
