using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickeryCard : Card
{
    Target target;
    Effect effect;

    public TrickeryCard(string displayName, string id) : base(displayName, id) {
    }

    public Target Target { get => target; private set => target = value; }

    public override void Apply(PlayerController playerController) {
        throw new System.NotImplementedException();
    }
}

public enum Target { Player, Plant, Building, Worker }