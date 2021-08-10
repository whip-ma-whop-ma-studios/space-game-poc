#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    public Speaker _speakerOne;
    public Speaker _speakerTwo;

    [SerializeField]
    private DialogueLine[] _dialogueLines;
    [SerializeField]
    public ObjectiveState _objectiveState;

    public DialogueLine GetLineByIndex(int index)
    {
        return _dialogueLines[index];
    }

    public int GetLength()
    {
        return _dialogueLines.Length;
    }
}
