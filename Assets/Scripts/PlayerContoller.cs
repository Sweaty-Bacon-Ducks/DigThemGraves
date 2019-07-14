using UnityEngine;

namespace DigThemGraves
{
    public class PlayerContoller : MonoBehaviour
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


