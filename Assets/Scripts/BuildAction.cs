using UnityEngine;

namespace DigThemGraves
{
    public class BuildAction : IAction
    {
        [SerializeField]
        private string actionName;

        private GameObject target;

        private Sprite sprite;

        public string Name
        {
            get
            {
                return actionName;
            }
        }

        private bool isFinished;
        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                isFinished = value;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public BuildAction(GameObject target, Sprite sprite)
        {
            this.target = target;
            this.sprite = sprite;
        }

        public void Execute()
        {
            target.GetComponent<SpriteRenderer>().sprite = sprite;
            IsFinished = true;
        }
    }
}
