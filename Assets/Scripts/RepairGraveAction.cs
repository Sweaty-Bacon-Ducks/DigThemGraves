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

		public override void Execute(IGrave graveContext)
        {
            graveContext.Health.Heal(repairAmmount);
        }
	}
}
