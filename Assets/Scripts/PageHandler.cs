using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PageHandler : MonoBehaviour
{
    [BoxGroup("Sprites")]
    [SerializeField] private Sprite _activePage, _inactivePage;
    [BoxGroup("Gameobject Reference")]
    [SerializeField] private GameObject _leftArrow, _rightArrow,_page1,_page2;
    [BoxGroup("Image Component Reference")]
    [SerializeField] private Image _page1Indicator, _page2Indicator;

    private void OnEnable()
    {
        Page1Active();
    }

    public void Start()
    {
        Page1Active();
    }

    public void Page1Active()
    {
        _page1Indicator.sprite = _activePage;
        _page2Indicator.sprite = _inactivePage;

        _leftArrow.SetActive(false);
        _rightArrow.SetActive(true);

        _page1.SetActive(true);
        _page2.SetActive(false);
    }

    public void Page2Active()
    {
        _page1Indicator.sprite = _inactivePage;
        _page2Indicator.sprite = _activePage;

        _leftArrow.SetActive(true);
        _rightArrow.SetActive(false);

        _page1.SetActive(false);
        _page2.SetActive(true);
    }


}
