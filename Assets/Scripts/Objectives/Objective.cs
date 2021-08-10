using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective", menuName = "Objectives/New Objective")]
public class Objective : ScriptableObject
{
    public ObjectiveState _currentState;
    public List<ObjectiveState> objectiveStates;

    public void IncrementState()
    {
        if (_currentState == null )
        {
            _currentState = objectiveStates[0];
        }

        _currentState = _currentState._nextState;
    }
}
 