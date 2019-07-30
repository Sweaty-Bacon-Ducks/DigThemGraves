using UnityEngine;

namespace DigThemGraves
{
	public class TearDownGraveAction : IAction
	{
		[SerializeField]
		private string actionName;

        private GameObject target;

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

        public TearDownGraveAction(GameObject target)
        {
            this.target = target;
        }

        public void Execute()
		{
            Debug.Log("Tearing grave");
		}
	}
}