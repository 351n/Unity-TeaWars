using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string nickname;
    public int gold;
    public PlantCard plant = new PlantCard("Marihuaeh","PLT");
    public PlantatorCard plantator = new PlantatorCard("Heniek Rolnik","PNT");
    public List<Card> hand = new List<Card>();

    void Start() {

    }


    void Update() {

    }

    internal void ApplyPlantEffect() {
        Debug.Log($"Applying {plant}");
        plant.Apply(this);
    }

    internal void ApplyPlantatorEffect() {
        Debug.Log($"Applying {plantator}");
        plantator.Apply(this);
    }
}
