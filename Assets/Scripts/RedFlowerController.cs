using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlowerController : Consumable, IInteractableObj
{
    [SerializeField]
    public List<QuestCollection> _relatedCollectionQuests;

    public void Interact()
    {
        Consume(10);
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
