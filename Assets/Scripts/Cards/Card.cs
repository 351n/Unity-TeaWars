using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card
{
    public readonly string displayName;
    public readonly string id;

    protected Card(string displayName, string id) {
        this.displayName = displayName;
        this.id = id;
    }

    public abstract void Apply(PlayerController playerController);

    public override string ToString() {
        return $"{displayName} <{id}>";
    }
}