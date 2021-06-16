using System.Collections;
using UnityEngine;

public class RocketController : SceneLoader, IInteractableObj
{
    [SerializeField]
    public string _sceneToLoad;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _animationTime;

    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        StartCoroutine(TransitionScene());
    }

    IEnumerator TransitionScene()
    {
        _player.SetActive(false);
        _animator.Play("RocketLiftOff");
        yield return new WaitForSeconds(_animationTime);
        LoadScene(_sceneToLoad);
    }
}
