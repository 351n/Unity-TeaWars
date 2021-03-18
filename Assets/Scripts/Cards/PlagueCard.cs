using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueCard : Card
{
    public Target target;
    public Effect effect = new Effect();

    public PlagueCard(string displayName, string id) : base(displayName, id) {
        target = Target.Player;
    }

    public override void Apply(PlayerController playerController) {
        throw new System.NotImplementedException();
    }

    public void Apply(List<PlayerController> players) {
        foreach(PlayerController p in players) {

        }
    }

    public override string ToString() {
        string result = base.ToString();
        result += $" T<{target}> E{effect}";
        return result;
    }
}
