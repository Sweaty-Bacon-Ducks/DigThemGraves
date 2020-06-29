using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
using AbstractionLib.QuestSystem;

public class QuestAcceptanceWindow : MonoBehaviour
{
    private Button acceptButton;
    private Button declineButton;

    public IQuest Quest { get; set; }

    private void Awake()
    {
        //acceptButton.BindToOnClick()
    }
}
