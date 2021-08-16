using System.Collections.Generic;
using UnityEngine;

public class YellowFlowerController : Consumable, IInteractableObj
{
    [SerializeField]
    public List<CollectionQuest> _relatedCollectionQuests;

    public void Interact(GameObject interactor)
    {
        Consume(-20);

        HealthManager healthManager = interactor.GetComponent<HealthManager>();
        if (healthManager != null)
        {
            healthManager.UpdateHealth(-20);
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
