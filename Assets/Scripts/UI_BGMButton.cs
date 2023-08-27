using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UI_BGMButton : MonoBehaviour
{
    [BoxGroup("Sprites")]
    [SerializeField] private Sprite _activeButton, _inactiveButton;
    [BoxGroup("Image Component Reference")]
    [SerializeField] private Image _bgmButton;
    [BoxGroup("Script Component Reference")]
    [SerializeField] private BGM _bgm;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private bool isClicked = false;

    public void Start()
    {
        if (!_playerData._isBGMOff) BGMButtonActive();
        else BGMButtonInactive();
    }

    public void OnClickBGMButton()
    {
        if (!isClicked) BGMButtonInactive();
        else BGMButtonActive();
    }

    private void BGMButtonActive()
    {
        _playerData._isBGMOff = false;
        isClicked = false;
        _bgm.UnpauseBGM();
        _bgm.PlayBGM();
        _bgmButton.sprite = _activeButton;
    }

    private void BGMButtonInactive()
    {
        _playerData._isBGMOff = true;
        isClicked = true;
        _bgm.PauseBGM();
        _bgmButton.sprite = _inactiveButton;
    }
}
