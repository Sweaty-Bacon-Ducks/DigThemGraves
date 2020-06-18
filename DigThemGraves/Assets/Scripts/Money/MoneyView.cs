using UnityEngine;
using UniRx;
using TMPro;

namespace DigThemGraves
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private MoneyPresenter moneyPresenter;

#pragma warning disable CS0649
        [SerializeField]
        private TextMeshProUGUI text;
#pragma warning restore CS0649

        private void Awake()
        {
            moneyPresenter.Model.MoneyAsObservable
                 .Subscribe(m =>
                 {
                     text.text = string.Format("{0}", m);
                 });
        }
    }
}