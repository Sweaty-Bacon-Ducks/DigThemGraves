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

        private Sprite sprite;
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

        public RepairGraveAction(GameObject target)
        {
            this.target = target;
        }

        public void Execute()
        {
            target.GetComponent<IGrave>().Health.Heal(repairAmmount);
        }
	}
}
