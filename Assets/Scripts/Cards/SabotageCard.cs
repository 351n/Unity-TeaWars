using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageCard : Card
{
    Target target;
    Effect effect;
}

public enum Target {Player,Plant,Building}
