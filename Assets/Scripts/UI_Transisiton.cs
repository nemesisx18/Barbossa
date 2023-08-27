using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class UI_Transisiton : MonoBehaviour
{
    [SerializeField] private bool _isFadeIn;
    [SerializeField] private bool _isFadeOut;
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private GameEventNoParam _onTransitionDone;
    [SerializeField] private GameEventNoParam _onEpilogTransitionDone;

    [SerializeField] bool isEpilog;

    private void Start()
    {
        gameObject.SetActive(false);
        if (!TryGetComponent<CanvasGroup>(out CanvasGroup canvasGroup)) return;
        if (_isFadeIn && !_isFadeOut)
        {
            canvasGroup.alpha = 1;
            BeginTransition();
        }
        if (!_isFadeIn && _isFadeOut)
        {
            canvasGroup.alpha = 0;
        }
    }

    public void BeginTransition()
    {
        gameObject.SetActive(true);
        if (!TryGetComponent<CanvasGroup>(out CanvasGroup canvasGroup)) return;
        if (_isFadeIn && !_isFadeOut)
        {
            canvasGroup.DOFade(0, _transitionSpeed).OnComplete(() =>
            {
                _onTransitionDone.Raise();
                gameObject.SetActive(false);
            });
        }

        if (!_isFadeIn && _isFadeOut)
        {
            canvasGroup.DOFade(1, _transitionSpeed).OnComplete(() =>
            {
                _onTransitionDone.Raise();
                if (isEpilog) StartCoroutine(BackToMainMenuDelayAfterEpilogueTransition());
            });

        }

    }

    IEnumerator BackToMainMenuDelayAfterEpilogueTransition()
    {
        yield return new WaitForSeconds(3f);
        _onEpilogTransitionDone.Raise();
    }
}

