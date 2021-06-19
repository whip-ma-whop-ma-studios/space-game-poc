using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public bool isSpeakerOne;
    [TextArea]
    public string dialogue;
    public AnimationClip? animation;
}
