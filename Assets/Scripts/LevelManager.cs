using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPlayer;
    [SerializeField]
    private List<CollectionQuest> _quests;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting POC Level!");
        // Set player health to max
        _mainPlayer.GetComponent<HealthManager>().SetMaxHealth();

        // Reset quests
        foreach (CollectionQuest q in _quests)
        {
            q.Reset();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
