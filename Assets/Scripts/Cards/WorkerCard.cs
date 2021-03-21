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
    }

    public override void Apply(PlayerController playerController) {
        throw new System.NotImplementedException();
    }
}
