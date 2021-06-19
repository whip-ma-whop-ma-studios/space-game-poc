using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation _conversation;
    public void StartConversation()
    {
        DialogueManager.StartConversation(_conversation);
    }
}
