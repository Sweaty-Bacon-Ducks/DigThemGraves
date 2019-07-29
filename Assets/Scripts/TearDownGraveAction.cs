using UnityEngine;

namespace DigThemGraves
{
	public class TearDownGraveAction : Action
	{
		[SerializeField]
		private string actionName;

        private GameObject target;

        public override string Name
		{
			get
			{
				return actionName;
			}
		}

        private bool isFinished;
        public override bool IsFinished
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

        public override void Execute()
		{
            Debug.Log("Tearing grave");
		}
	}
}