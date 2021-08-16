using System.Collections.Generic;
using UnityEngine;

public class ConversationStarter : MonoBehaviour, IInteractableObj
{
    [SerializeField]
    private ConversationManager _conversationManager;
    
    [SerializeField]
    private GameObject _dialogueUI;

    [SerializeField]
    public List<QuestCollection> _relatedCollectionQuests;

    public void Interact()
    {
        _dialogueUI.SetActive(true);
        Time.timeScale = 0;
        PlayerInputController.PlayerInputEnabled = false;

        foreach (QuestCollection q in _relatedCollectionQuests)
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
                DialogueManager.StartConversation(q.startConversation);
                return;
            }
            else if (q.IsCompleted())
            {
                // just completed, finish it
                DialogueManager.StartConversation(q.endConversation);
                Debug.Log("Checking finished quest: " + q._name);
                q.Finish();
                return;
            }
            else if (q.IsStarted())
            {
                // started and in progress, but not complete
                Debug.Log("In mid quest: " + q._name);
                DialogueManager.StartConversation(q.startConversation);
                return;
            }
        }

        // No quests unlocked & started, play random conversation
        DialogueManager.StartConversation(_conversationManager.ChooseConversation());
    }
}
