using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    [CreateAssetMenu]
    public class ActiveBuildSlot : ScriptableObject
    {
        private BuildSlot activeSlot;

        public BuildSlot ActiveSlot
        {

            get { return activeSlot; }

            set { activeSlot = value; }

        }
    }
}

