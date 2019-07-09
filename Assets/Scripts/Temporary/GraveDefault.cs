using DigThemGraves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveDefault : Grave
{
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private ActiveBuildSlot activeSlot;

    public override IGraveActions AvailableActions => throw new System.NotImplementedException();

    public override IGraveHealth Health => throw new System.NotImplementedException();

    public override void Build()
    {
        activeSlot.ActiveSlot.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}

/// Sprite powinno mieć każde IBuildable, tylko że staramy się uniezależnić interfejsy od unity