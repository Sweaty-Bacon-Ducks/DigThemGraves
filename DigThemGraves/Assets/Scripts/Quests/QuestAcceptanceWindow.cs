using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace DigThemGraves
{
    public class QuestAcceptanceWindow : MonoBehaviour
    {
        [SerializeField]
        private Button acceptButton;
        [SerializeField]
        private Button declineButton;
        [SerializeField]
        private TextMeshProUGUI titleField;
        [SerializeField]
        private TextMeshProUGUI descriptionField;
        [SerializeField]
        private QuestController questController;

        public UnityEvent QuestAccepted { get; private set; }
        public UnityEvent QuestDeclined { get; private set; }

        //TODO: Przekształcić na pole inicjowane w awakeu ponieważ tworzymy cały czas nową lambdę 
        private UnityAction onAccept => () =>
        {
            questController.AddQuest(Quest.MakeActive());
            gameObject.SetActive(false);
        };

        private UnityAction onDecline => () =>
        {
            gameObject.SetActive(false);
        };

        public ReactiveQuest Quest { get; set; }

        private void Awake()
        {
            titleField.text = Quest.Title;
            descriptionField.text = Quest.Description;
            QuestAccepted = new UnityEvent();
            QuestAccepted.AddListener(onAccept);
            QuestDeclined = new UnityEvent();
            QuestDeclined.AddListener(onDecline);
            acceptButton.onClick.AddListener(() => QuestAccepted.Invoke());
            declineButton.onClick.AddListener(() => QuestDeclined.Invoke());
        }

        private void OnDestroy()
        {
            acceptButton.onClick.RemoveListener(onAccept);
            declineButton.onClick.RemoveListener(onDecline);
        }
    }
}

