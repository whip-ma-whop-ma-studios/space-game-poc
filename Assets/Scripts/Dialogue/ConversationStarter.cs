using System.Collections.Generic;
using UnityEngine;

public class ConversationStarter : MonoBehaviour, IInteractableObj
{
    [SerializeField]
    private ConversationManager _conversationManager;
    
    [SerializeField]
    private GameObject _dialogueUI;

    [SerializeField]
    public List<CollectionQuest> _relatedCollectionQuests;

    public void Interact(GameObject interactor)
    {
        _dialogueUI.SetActive(true);
        Time.timeScale = 0;
        PlayerInputController.PlayerInputEnabled = false;

        foreach (CollectionQuest q in _relatedCollectionQuests)
        {
            // Check through quests to find relevent one
            if (q.IsLocked())
            {
                // This quest is still locked, try the next
                continue;
            }            
            else if (q.IsUnlocked())
            {
                // Quest is unlocked, start it
                Debug.Log("Starting quest: " + q._name);
                q.Start();
                DialogueManager.StartConversation(q._startConversation);
                return;
            }
            else if (q.IsCompleted())
            {
                // just completed, finish it
                DialogueManager.StartConversation(q._endConversation);
                Debug.Log("Checking finished quest: " + q._name);
                q.Finish();
                return;
            }
            else if (q.IsStarted())
            {
                // started and in progress, but not complete
                Debug.Log("In mid quest: " + q._name);
                DialogueManager.StartConversation(q._midConversation);
                return;
            }
        }

        // No quests unlocked & started, play random conversation
        DialogueManager.StartConversation(_conversationManager.ChooseConversation());
    }
}
