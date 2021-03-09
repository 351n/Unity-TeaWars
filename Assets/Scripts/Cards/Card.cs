using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card { 
    public readonly string displayName;
    public readonly string id;

    public abstract void Apply();

    public abstract void Apply(PlayerController playerController);
}
