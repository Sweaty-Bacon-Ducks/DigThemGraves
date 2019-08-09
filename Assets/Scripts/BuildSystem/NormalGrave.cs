using UnityEngine;

namespace DigThemGraves
{
    public class NormalGrave : Grave
    {
        [SerializeField]
        private Sprite sprite;

        public override IActions AvailableActions { get { return AvailableActions; } }
        public override IHealth Health { get { return Health; } }

        private IBuildSlot occupiedSlot;
        public override IBuildSlot OccupiedSlot
        {
            get { return occupiedSlot; }
            set { occupiedSlot = value; }
        }

        private BuildSlot targetedBuildSlot;
        public override BuildSlot TargetedBuildSlot
        {
            get { return targetedBuildSlot; }
            set { targetedBuildSlot = value; }
        }

        public override void Build()
        {
            ActionQueue actionQueue = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ActionQueue>();

            TargetedBuildSlot.GetComponent<SpriteRenderer>().sprite = sprite;

            actionQueue.AddAction(new BuildAction(TargetedBuildSlot.gameObject, sprite));
            actionQueue.AddAction(new BuildAction(TargetedBuildSlot.gameObject, sprite));

            OccupiedSlot = TargetedBuildSlot;
        }
    }
}
