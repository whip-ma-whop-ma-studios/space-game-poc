using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private Conversation[] _conversations;

    public Conversation ChooseConversation()
    {
        int random = Random.Range(0, _conversations.Length);
        return _conversations[random];
    }
}
