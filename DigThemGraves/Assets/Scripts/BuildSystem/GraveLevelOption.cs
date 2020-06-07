using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UniRx;

namespace DigThemGraves
{
    [RequireComponent(typeof(Button))]
    public class GraveLevelOption : MonoBehaviour
    {
        public uint Value;

        private Button button;
        private IObservable<uint> selectedOptionAsObservable;

        public IObservable<uint> SelectedOptionAsObservable
        {
            get
            {
                if (selectedOptionAsObservable is null)
                {
                    selectedOptionAsObservable = GetButton().OnClickAsObservable()
                                                            .Select(_ => Value);
                }
                return selectedOptionAsObservable;
            }
        }

        private void Awake()
        {
            button = GetButton();
        }

        private Button GetButton()
        {
            if (!button)
            {
                button = GetComponent<Button>();
            }
            return button;
        }

        public override string ToString()
        {
            return $"{{ \"value\": {Value}}}";
        }
    }
}