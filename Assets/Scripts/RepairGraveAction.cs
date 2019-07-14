using UnityEngine;

namespace DigThemGraves
{
	[CreateAssetMenu(menuName = "InGame", fileName = "RepairGraveAction")]
	public class RepairGraveAction : GraveAction
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

		public override void Execute(IBuildable buildable) // IGrave graveContext
        {
            //buildable.Health.Heal(repairAmmount);  // graveContext.Health.Heal(repairAmmount);
        }
	}
}
