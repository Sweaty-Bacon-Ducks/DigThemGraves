using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveBuildSlot : BuildSlot
    {
        public override IBuildable Occupant { get { return Occupant; } }

        public override List<IBuildable> PossibleBuildables { get { return PossibleBuildables; } }


        void OnMouseDown()
        {

        }
    }
}
