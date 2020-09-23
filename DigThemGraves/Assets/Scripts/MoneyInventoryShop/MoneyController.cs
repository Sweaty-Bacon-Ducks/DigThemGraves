using UnityEngine;

namespace DigThemGraves
{
    public class MoneyController : MonoBehaviour, IController<Money>
    {
        private Money _model;
        public Money Model => _model;

        [SerializeField] private Sprite moneySprite;
        public Sprite Sprite => Model.Sprite;

        private void Awake()
        {
            _model = new Money(moneySprite);
        }

        public bool CanAfford(float amount)
        {
            return Model.CanAfford(amount);
        }

        public void AddMoney(float amount)
        {
            Model.Add(amount);
        }

        public void SubtractMoney(float amount)
        {
            Model.Substract(amount);
        }
    }
}