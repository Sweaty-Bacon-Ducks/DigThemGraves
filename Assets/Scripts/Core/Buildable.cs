using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public abstract class Buildable : MonoBehaviour, IBuildable
    {
        public abstract IActions AvailableActions { get; }
        public abstract IBuildSlot OccupiedSlot { get; set; }

        public abstract BuildSlot TargetedBuildSlot { get; set; }

        public abstract void Build();
    }
}
