using System.Collections.Generic;
using UnityEngine;

public class YellowFlowerController : Consumable, IInteractableObj, IQuestUpdater
{
    [SerializeField]
    public List<QuestCollection> _relatedCollectionQuests;

    public void Interact()
    {
        Consume(-20);
        ProgressQuest();
    }

    public void ProgressQuest()
    {
        foreach (QuestCollection q in _relatedCollectionQuests)
        {
            // Check all related quests for the first that can be progressed
            if (q.IsStarted())
            {
                Debug.Log("Incremented quest: " + q._name);
                q.IncrementAmount(1);
            }
        }
    }
}
