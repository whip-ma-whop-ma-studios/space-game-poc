using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private Conversation[] _standardConversations;

    public Conversation ChooseConversation()
    {
        int random = Random.Range(0, _standardConversations.Length);
        return _standardConversations[random];
    }
}
