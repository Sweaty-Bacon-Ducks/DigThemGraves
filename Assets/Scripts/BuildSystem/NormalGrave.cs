using UnityEngine;

namespace DigThemGraves
{
    public class NormalGrave : Grave
    {
        [SerializeField]
        private Sprite sprite;

        [SerializeField]
        private ActiveBuildSlot activeSlot;

        public override IGraveActions AvailableActions { get { return AvailableActions; } }

        public override IGraveHealth Health { get { return Health; } }

        public override IBuildSlot OccupiedSlot
        {
            get { return OccupiedSlot; }
            set { OccupiedSlot = value; }
        }

        public override IBuildSlot TargetedBuildSlot
        {
            get { return TargetedBuildSlot; }
            set { TargetedBuildSlot = value; }
        }

        public override void Build()
        {
            activeSlot.ActiveSlot.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
