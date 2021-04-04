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

    public Stack<PlagueCard> discardPlagueStack = new Stack<PlagueCard>();
    public Stack<Card> discardCardsStack = new Stack<Card>();

    void Start() {
        for(int i = 0; i < 5; i++) {
            plagueStack.Push(new PlagueCard("Test Plague Card", "CRD_PLG_1"));

            cardsStack.Push(new TrickeryCard("Test Trickery Card", "CRD_TRC_1"));

            cardsStack.Push(new WorkerCard("Test Worker Card", "CRD_WRK_1", new Effect(gold: 1, cardDraw: 2), new Effect(gold: 1, cardDraw: 3)));

            cardsStack.Push(new AssetCard("Test Asset Card", "CRD_AST_1"));
        }
    }

    public PlagueCard GetPlagueCard() {
        return plagueStack.Peek();
    }

    internal Card Draw() {
        if(cardsStack.Count > 1) {
            return cardsStack.Pop();
        } else {
            return cardsStack.Peek();
        }
    }

    public void Discard(Card card) {
        discardCardsStack.Push(card);
    }

    public void Discard(PlagueCard card) {
        discardPlagueStack.Push(card);
    }
}
