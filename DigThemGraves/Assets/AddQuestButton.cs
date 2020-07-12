using UnityEngine;
using UnityEngine.UI;
using DigThemGraves;
using UniRx;

[RequireComponent(typeof(Button)), RequireComponent(typeof(ReactiveQuest))]
public class AddQuestButton : MonoBehaviour
{
    private Button button;
    [SerializeField]
    private QuestAcceptanceWindow questAcceptanceWindow;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => questAcceptanceWindow.gameObject.SetActive(true));
        questAcceptanceWindow.Quest = GetComponent<ReactiveQuest>();
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
}
