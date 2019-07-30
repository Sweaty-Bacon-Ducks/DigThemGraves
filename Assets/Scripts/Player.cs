using UnityEngine;

namespace DigThemGraves
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private PlayerActions availableActions;

        public PlayerActions AvailableActions { get; }

        public void ExecuteAllActions()
        {
			foreach (var action in AvailableActions)
            {
                action.Execute(this);
            }
        }
    }
}