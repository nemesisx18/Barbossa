using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UI_LifepointBar : MonoBehaviour
{
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Value")]
    [SerializeField] private int _currentLifePoint;
    public int CurrentLifePoint
    {
        get
        {
            return _currentLifePoint;
        }
        set
        {
            _currentLifePoint = value;
            if (_currentLifePoint <= 0)
            {
                _currentLifePoint = 0;
            }

            if (_currentLifePoint > 3)
            {
                _currentLifePoint = 3;
            }
        }
    }
    [BoxGroup("Sprite References")]
    [SerializeField] private Sprite[] _lifePointSprites;
    [BoxGroup("Component References")]
    [SerializeField] private Image _lifePointImageComponent;


    private void Start()
    {
        CurrentLifePoint = _playerData.TotalLifePoint;
        _lifePointImageComponent.sprite = _lifePointSprites[CurrentLifePoint];
    }

    public void OnIncreaseLifePointBar()
    {
        CurrentLifePoint++;
        _playerData.TotalLifePoint++;
        _lifePointImageComponent.sprite = _lifePointSprites[CurrentLifePoint];
    }
}
