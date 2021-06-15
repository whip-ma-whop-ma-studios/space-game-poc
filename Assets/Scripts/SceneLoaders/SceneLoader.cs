using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Animator _sceneLoaderAnimator;
    [SerializeField]
    private float _sceneLoaderAnimationTime;


    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneWithAnimation(scene));
    }

    IEnumerator LoadSceneWithAnimation(string scene)
    {
        _sceneLoaderAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(_sceneLoaderAnimationTime);

        SceneManager.LoadScene(scene);
    }
}
