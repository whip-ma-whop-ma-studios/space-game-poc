using System.Collections;
using UnityEngine;

public class InteractionPopupController : MonoBehaviour
{
    [SerializeField]
    private float _animationTime;

    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(ClosePopup());
        }
    }

    private IEnumerator ClosePopup()
    {
        _animator.Play("ScaleDown");
        yield return new WaitForSeconds(_animationTime);
        gameObject.SetActive(false);
    }
}
