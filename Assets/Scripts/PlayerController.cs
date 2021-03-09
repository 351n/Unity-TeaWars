using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string nickname;
    public int gold;
    public PlantCard plant;
    public PlantatorCard plantator;
    public List<Card> hand;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    internal void ApplyPlantEffect() {
        plant.Apply(this);
    }

    internal void ApplyPlantatorEffect() {
        plantator.Apply(this);
    }
}
