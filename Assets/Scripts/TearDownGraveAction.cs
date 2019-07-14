using UnityEngine;

namespace DigThemGraves
{
	[CreateAssetMenu(menuName = "InGame", fileName = "TearDownGraveAction")]
	public class TearDownGraveAction : GraveAction
	{
		[SerializeField]
		private string actionName;
		public override string Name
		{
			get
			{
				return actionName;
			}
		}

		public override void Execute(IBuildable buildable)
		{
			
		}
	}
}