using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// QuestManager currently only used to reset quests on scene load for testing purposes
// May not be needed
public class QuestManager : MonoBehaviour
{
    public List<CollectionQuest> _quests;

    void Start()
    {
        foreach (CollectionQuest q in _quests)
        {
            q.Reset();
        }
    }
}
