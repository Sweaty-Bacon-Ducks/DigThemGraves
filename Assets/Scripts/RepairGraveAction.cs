using UnityEngine;

namespace DigThemGraves
{
	public class RepairGraveAction : Action
	{
		[SerializeField]
		private int repairAmmount;
		[SerializeField]
		private string actionName;
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

        public override void Execute(GameObject target)
        {
            target.GetComponent<IGrave>().Health.Heal(repairAmmount);
        }
	}
}
