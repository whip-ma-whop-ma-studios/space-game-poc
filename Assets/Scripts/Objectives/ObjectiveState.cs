using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective State", menuName = "Objectives/New Objective State")]
public class ObjectiveState : ScriptableObject
{
    public string stateName { get; set; }

    public ObjectiveState _nextState;
}
