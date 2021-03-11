using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetCard : Card
{
    public AssetCard(string displayName, string id) : base(displayName, id) {
    }

    public override void Apply(PlayerController playerController) {
        throw new System.NotImplementedException();
    }
}
