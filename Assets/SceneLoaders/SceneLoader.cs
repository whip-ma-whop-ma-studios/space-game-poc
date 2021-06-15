using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator _transition;
    public float _transitionTime;

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneWithAnimation(scene));
    }

    IEnumerator LoadSceneWithAnimation(string scene)
    {
        _transition.SetTrigger("Start");

        yield return new WaitForSeconds(_transitionTime);

        SceneManager.LoadScene(scene);
    }
}
