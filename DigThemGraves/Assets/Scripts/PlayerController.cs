using UnityEngine;

namespace DigThemGraves
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayer currentPlayer;

        private void Awake()
        {
            currentPlayer = GetComponent<IPlayer>();
        }

        private void Update()
        {
            currentPlayer.ExecuteAllActions();
        }
    }
}
