using DigThemGraves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSlotDefault : BuildSlot
{
    public override IBuildable Occupant => throw new System.NotImplementedException();
}
