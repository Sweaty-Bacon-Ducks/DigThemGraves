using UnityEngine;

namespace DigThemGraves
{
	public class RepairGraveAction : IAction
	{
		[SerializeField]
		private int repairAmmount;
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

        public RepairGraveAction(GameObject target)
        {
            this.target = target;
        }

        public void Execute()
        {
            Debug.Log("Repairing grave");
            target.GetComponent<IGrave>().Health.Heal(repairAmmount);
        }
	}
}
