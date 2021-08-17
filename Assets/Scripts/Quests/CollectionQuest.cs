using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collection Quest", menuName = "Quests/New Collection Quest")]
public class CollectionQuest : ScriptableObject
{
    public enum State
    {
        Locked,
        Unlocked,
        Started,
        Completed,
        Finished,
    }

    [SerializeField]
    public string _name;
    [SerializeField]
    public string _description;
    [SerializeField]
    public int _startAmount = 0;
    [SerializeField]
    public int _endAmount;
    [SerializeField]
    public bool _startUnlocked = true;
    [SerializeField]
    public Conversation _startConversation;
    [SerializeField]
    public Conversation _midConversation;
    [SerializeField]
    public Conversation _endConversation;
    [SerializeField]
    public List<CollectionQuest> _unlockQuestsOnCompletion;
    [SerializeField]
    public List<CollectionQuest> _startQuestsOnCompletion;
    [SerializeField]
    public int _currentAmount = 0;
    [SerializeField]
    private State _currentState;

    public void Reset()
    {
        _currentAmount = 0;
        _currentState = State.Locked;
        if (_startUnlocked)
        {
            _currentState = State.Unlocked;
        }
    }

    public void IncrementAmount(int incrementAmount)
    {
        _currentAmount += incrementAmount;

        if (_currentAmount >= _endAmount)
        {
            _currentAmount = _endAmount;
            _currentState = State.Completed;
        }
    }

    public bool IsLocked()
    {
        return _currentState == State.Locked;
    }

    public bool IsUnlocked()
    {
        return _currentState == State.Unlocked;
    }

    public bool IsStarted()
    {
        return _currentState == State.Started;
    }

    public bool IsCompleted()
    {
        return _currentState == State.Completed;
    }

    public bool IsFinsihed()
    {
        return _currentState == State.Finished;
    }

    public void Lock ()
    {
        _currentState = State.Locked;
    }

    public void Unlock()
    {
        if (_currentState == State.Locked)
        {
            _currentState = State.Unlocked;
        }
        // TODO Error
    }

    public void Start()
    {
        if (_currentState == State.Unlocked)
        {
            _currentState = State.Started;
        }
        // TODO Error
    }

    public void Complete()
    {
        if (_currentState == State.Started)
        {
            _currentState = State.Completed;
        }
        // TODO Error
    }

    public void Finish()
    {
        if (_currentState == State.Completed)
        {
            _currentState = State.Finished;
        }

        foreach (CollectionQuest q in _unlockQuestsOnCompletion)
        {
            Debug.Log("Unlocking " + q._name);
            q.Unlock();
        }

        foreach (CollectionQuest q in _startQuestsOnCompletion)
        {
            Debug.Log("Starting " + q._name);
            q.Start();
        }
        // TODO Error
    }

    public string GenerateProgressText()
    {
        return _description + "\n\n" + "<b>" + _currentAmount + "/" + _endAmount + "</b>";
    }
}
