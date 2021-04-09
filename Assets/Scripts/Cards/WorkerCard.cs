using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCard : Card
{
    uint hireCost = 2;
    Effect useEffect;
    Effect fireEffect;

    public uint HireCost { get => hireCost; set => hireCost = value; }

    public WorkerCard(string displayName, string id) : base(displayName, id) {
        this.useEffect = new Effect();
        this.fireEffect = new Effect();
    }

    public WorkerCard(string displayName, string id, Effect effect, Effect fireEffect) : base(displayName, id) {
        this.useEffect = effect;
        this.fireEffect = fireEffect;
    }

    public override void Apply(PlayerController playerController) {
        playerController.ApplyEffect(useEffect);

    }

    internal string GetEffectText() {
        string result = "";

        if(useEffect != null && fireEffect != null) {
            result = $"{useEffect}\n\nZwolnij:\n{fireEffect}";
        } else if(fireEffect != null) {
            result = $"Zwolnij:\n{fireEffect}";
        } else {
            result = $"{useEffect}";
        }

        return result;
    }
}
