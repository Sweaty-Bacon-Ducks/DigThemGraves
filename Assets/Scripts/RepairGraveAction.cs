using UnityEngine;

namespace DigThemGraves
{
	public class RepairGraveAction : Action
	{
		[SerializeField]
		private int repairAmmount;
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

        public RepairGraveAction(GameObject target)
        {
            this.target = target;
        }

        public override void Execute()
        {
            Debug.Log("Repairing grave");
            target.GetComponent<IGrave>().Health.Heal(repairAmmount);
        }
	}
}
