using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestMenuManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI _textBody;
    [SerializeField]
    public GameObject _questMenu;
    [SerializeField]
    private List<CollectionQuest> _quests;

    private GameObject QuestMenu;

    // TODO Dispose when not in view?

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            // Reset text body
            _textBody.text = "";

            // Add descriptions for all in progress quests
            foreach (CollectionQuest q in _quests)
            {
                if (q.IsStarted() || q.IsCompleted())
                {
                    _textBody.text += q.GenerateProgressText() + "\n\n";
                }
            }

            _questMenu.SetActive(true);
        }
        else
        {
            _questMenu.SetActive(false);
        }
    }
}
