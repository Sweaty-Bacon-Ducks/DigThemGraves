using UnityEngine;
namespace DigThemGraves
{
	public class MovePlayerAction : MonoBehaviour, IAction
	{
		[SerializeField]
		private Transform target;
		[SerializeField]
		private Camera playerCamera;
		[SerializeField]
		private float zOffset;
		[SerializeField]
		private LayerMask invalidWalkingLayers;
		private InputClick clickGateway;

		public bool IsFinished { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private Sprite sprite;
        public override Sprite Sprite
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

        public void Awake()
		{
			clickGateway = InputClick.Create();
		}

		private void Update()
		{

			Execute();
		}

		public void Execute()
		{
			var clickData = clickGateway.ClickPoint;
			if (clickData.Clicked)
			{
				if (ValidWalkingTerrain(clickData.OnScreenClickPoint))
				{
					var worldClickPosition = playerCamera.ScreenToWorldPoint(clickData.OnScreenClickPoint);
					worldClickPosition.z = zOffset;
					target.position = worldClickPosition;
				}
			}
		}

        public override void Cancel()
        {

        }
    }
}