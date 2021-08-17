using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlowerController : Consumable, IInteractableObj
{
    [SerializeField]
    public List<CollectionQuest> _relatedCollectionQuests;

    public void Interact(GameObject interactor)
    {
        Consume(10);
        
        HealthManager healthManager = interactor.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.UpdateHealth(10);
        }
        
        ProgressQuest();
    }

    public void ProgressQuest()
    {
        foreach (CollectionQuest q in _relatedCollectionQuests)
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
