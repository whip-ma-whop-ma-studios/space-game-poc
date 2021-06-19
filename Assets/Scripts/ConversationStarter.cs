using UnityEngine;

public class ConversationStarter : MonoBehaviour, IInteractableObj
{
    [SerializeField]
    private ConversationManager _conversationManager;
    
    [SerializeField]
    private GameObject _dialogueUI;

    public void Interact()
    {
        _dialogueUI.SetActive(true);
        Time.timeScale = 0;
        DialogueManager.StartConversation(_conversationManager.ChooseConversation());
    }
}

