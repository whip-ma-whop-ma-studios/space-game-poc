using System.Collections.Generic;
using UnityEngine;

public class ConversationStarter : MonoBehaviour, IInteractableObj
{
    [SerializeField]
    private ConversationManager _conversationManager;
    
    [SerializeField]
    private GameObject _dialogueUI;

    [SerializeField]
    public Objective _relatedObjective;

    public void Interact()
    {
        Debug.Log("Completed current part of quest!" + _relatedObjective.name);
        Debug.Log("Current state!" + _relatedObjective._currentState);
        _dialogueUI.SetActive(true);
        Time.timeScale = 0;
        DialogueManager.StartConversation(_conversationManager.ChooseConversation());
        PlayerInputController.PlayerInputEnabled = false;
    }

    public void CheckRequiredState()
    {

    }

    public void TransitionToNextState()
    {
        
    }
}
