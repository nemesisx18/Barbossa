using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class UI_SFXButton : MonoBehaviour
{
    [BoxGroup("Sprites")]
    [SerializeField] private Sprite _activeButton, _inactiveButton;
    [BoxGroup("Image Component Reference")]
    [SerializeField] private Image _sfxButton;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private bool isClicked = false;

    public void Start()
    {
        if (!_playerData._isBGMOff) SFXButtonActive();
        else SFXButtonInactive();
    }

    public void OnClickSFXButton()
    {
        if (!isClicked) SFXButtonInactive();
        else SFXButtonActive();
    }

    private void SFXButtonActive()
    {
        _playerData._isSFXOff = false;
        isClicked = false;
        _sfxButton.sprite = _activeButton;
    }

    private void SFXButtonInactive()
    {
        _playerData._isSFXOff = true;
        isClicked = true;
        _sfxButton.sprite = _inactiveButton;
    }
}
