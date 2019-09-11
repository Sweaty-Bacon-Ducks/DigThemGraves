using UnityEngine;
namespace DigThemGraves
{
	[CreateAssetMenu(menuName = "PlayerActions/Move", fileName = "MovePlayerAction")]
	public class MovePlayerAction : ScriptablePlayerAction
	{
		[SerializeField]
		private Vector3 target;
		[SerializeField]
		private Camera playerCamera;
		[SerializeField]
		private float zOffset;
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

		public MovePlayerAction(GameObject target2)
		{
            target = target2.transform.position;
		}
		public override void Execute()
		{
			var clickData = clickGateway.ClickPoint;
			if (clickData.Clicked)
			{
				var worldClickPosition = playerCamera.ScreenToWorldPoint(clickData.OnScreenClickPoint);
			}
		}

        public override void Cancel()
        {

        }
    }
}