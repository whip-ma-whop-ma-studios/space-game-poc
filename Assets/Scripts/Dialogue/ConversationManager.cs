using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    [SerializeField]
    private Conversation[] _objectiveConversations;
    [SerializeField]
    private Conversation[] _standardConversations;
    
    [SerializeField]
    private Objective _relatedObjective;

    public Conversation ChooseConversation()
    {
        if (_relatedObjective != null && _relatedObjective._currentState != null)
        {
            // Conversations related to an objective and we're in an objective state
            foreach (Conversation conv in _objectiveConversations)
            {
                if (conv._objectiveState != null && conv._objectiveState == _relatedObjective._currentState)
                {
                    _relatedObjective.IncrementState();
                    return conv;
                }
            }
        }

        int random = Random.Range(0, _standardConversations.Length);
        return _standardConversations[random];
    }
}
