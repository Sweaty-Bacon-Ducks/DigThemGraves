using AbstractionLib.QuestSystem;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class QuestController : MonoBehaviour, IQuestRepository
{
    private Quests questRepository;

    public ReadOnlyCollection<IQuest> AvailableQuests => questRepository.AvailableQuests;

    public ReadOnlyCollection<IQuest> ActiveQuests => questRepository.AvailableQuests;

    public ReadOnlyCollection<IQuest> FinishedQuests => questRepository.FinishedQuests;

    public ReadOnlyCollection<IQuest> FailedQuests => questRepository.FailedQuests;


    public void AddQuest(IQuest incomingQuest)
    {
        questRepository.AddQuest(incomingQuest);
    }

    public void AddManyQuests(IEnumerable<IQuest> incomingQuests)
    {
        questRepository.AddManyQuests(incomingQuests);
    }

    public void Reset()
    {
        questRepository.Reset();
    }

    public void Awake()
    {
        questRepository = new Quests();
    }

}
