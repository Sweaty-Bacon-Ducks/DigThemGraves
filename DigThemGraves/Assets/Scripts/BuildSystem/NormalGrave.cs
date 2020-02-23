using UnityEngine;

namespace DigThemGraves
{
    public class NormalGrave : Grave
    {
        [SerializeField]
        private Sprite sprite;

        public override IActions AvailableActions { get { return AvailableActions; } }
        public override IHealth Health { get { return Health; } }

        private BuildSlot occupiedSlot;
        public override BuildSlot OccupiedSlot
        {
            get { return occupiedSlot; }
            set { occupiedSlot = value; }
        }

        public override void Build()
        {
            ActionQueue actionQueue = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ActionQueue>();

            occupiedSlot.GetComponent<SpriteRenderer>().sprite = sprite;

            actionQueue.AddAction(new BuildAction(occupiedSlot.gameObject, sprite));
            actionQueue.AddAction(new BuildAction(occupiedSlot.gameObject, sprite));
        }
    }
}
