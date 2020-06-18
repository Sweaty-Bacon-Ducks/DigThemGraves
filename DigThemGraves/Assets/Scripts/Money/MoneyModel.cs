using UnityEngine;
using UniRx;
using System;

namespace DigThemGraves
{
    public class MoneyModel
    {
        [SerializeField]
        private FloatReactiveProperty _moneyReactiveProperty;
        public IObservable<float> MoneyAsObservable => _moneyReactiveProperty.AsObservable();

        [SerializeField]
        private Sprite _sprite;
        public Sprite Sprite { get; private set; }

        public MoneyModel(Sprite sprite)
        {
            _moneyReactiveProperty = new FloatReactiveProperty(0);
            this.Sprite = sprite;
        }

        public bool CanAfford(float amount)
        {
            return (_moneyReactiveProperty.Value - amount) >= 0;
        }

        public void Add(float amount)
        {
            _moneyReactiveProperty.Value += amount;
        }

        public void Substract(float amount)
        {
            if (_moneyReactiveProperty.Value < amount)
            {
                Debug.LogWarning("The money is negative! Did you wanted to use SubstractWithNegatives?");
            }
            _moneyReactiveProperty.Value -= amount;
        }

        // Nie blokuję wartości < 0 żeby można było mieć długi
        public void SubstractWithNegatives(float amount)
        {
            _moneyReactiveProperty.Value -= amount;
        }
    }
}