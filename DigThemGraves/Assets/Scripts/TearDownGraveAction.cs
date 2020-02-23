using UnityEngine;

namespace DigThemGraves
{
	public class TearDownGraveAction : IAction
	{
		[SerializeField]
		private string actionName;

        private GameObject target;

        private Sprite sprite;

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

        public TearDownGraveAction(GameObject target)
        {
            this.target = target;
        }

        public void Execute()
		{
            isFinished = true;
		}

        public void Cancel()
        {

        }
    }
}