using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerCard : Card
{
    int hireCost = 2;
    Effect useEffect;
    Effect fireEffect;

    public WorkerCard(string displayName, string id) : base(displayName, id) {
    }

    public override void Apply(PlayerController playerController) {
        throw new System.NotImplementedException();
    }
}
