#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogue/New Speaker")]
public class Speaker : ScriptableObject
{
    [SerializeField]
    private string _speakerName;
    [SerializeField]
    private GameObject _speakerObject;

    public string getSpeakerName()
    {
        return _speakerName;
    }

    public GameObject getSpeakerObject()
    {
        return _speakerObject;
    }
}
