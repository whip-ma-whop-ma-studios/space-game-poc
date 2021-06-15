using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : SceneLoader, IInteractableObj
{
    [SerializeField, Tooltip("Scene to go to")]
    public string _sceneToLoad;
    [SerializeField, Tooltip("Player")]
    private GameObject _player;

    private Animator _animator;

    public void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        StartCoroutine(RunAnimation());
    }

    IEnumerator RunAnimation()
    {
        Debug.Log("Going up!");
        _player.SetActive(false);
        _animator.Play("RocketLiftOff");
        yield return new WaitForSeconds(_transitionTime);
        LoadScene(_sceneToLoad);
    }
}
