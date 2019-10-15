using UnityEngine;
namespace DigThemGraves
{
	public class MovePlayerAction : PlayerAction
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

        public override bool IsFinished { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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

		public override void Execute()
		{
			var clickData = clickGateway.ClickPoint;
			if (clickData.Clicked)
			{
				var worldClickPosition = playerCamera.ScreenToWorldPoint(clickData.OnScreenClickPoint);
				if (ValidWalkingTerrain(worldClickPosition))
				{
					worldClickPosition.z = zOffset;
					target.position = worldClickPosition;
				}
			}
		}

		private bool ValidWalkingTerrain(Vector2 point)
		{
			var foundCollider = Physics2D.OverlapPoint(point,
													   invalidWalkingLayers);
			return foundCollider == null;
		}

        public override void Cancel()
        {

        }
    }
}