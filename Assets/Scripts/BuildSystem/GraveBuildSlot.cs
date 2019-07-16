using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveBuildSlot : BuildSlot
    {
        [SerializeField]
        private BuildableMenuDisplay buildableMenuDisplay;

        public override IBuildable Occupant { get { return Occupant; } }

        [SerializeField]
        private List<Buildable> possibleBuildables;

        public override List<Buildable> PossibleBuildables
        {
            get { return possibleBuildables; }
        }

        public override void OnMouseDown()
        {
            buildableMenuDisplay.ActivateMenu(possibleBuildables, this);
        }
    }
}