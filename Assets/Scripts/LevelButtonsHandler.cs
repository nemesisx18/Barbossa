using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsHandler : MonoBehaviour
{
    [SerializeField] GameObject[] _levelButtons;
    [SerializeField] PlayerDataScriptableObject _playerData;
    [SerializeField] Color _unlockedColor;
    [SerializeField] Color _lockedColor;

    private void Start()
    {
        UpdateLevelButtonState();
    }

    public void UpdateLevelButtonState()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i < _playerData.UnlockedLevel)
            {
                if (!_levelButtons[i].TryGetComponent<Image>(out Image image)) return;
                image.color = _unlockedColor;
                if (!_levelButtons[i].TryGetComponent<Button>(out Button button)) return;
                button.enabled = true;
            }
            else
            {
                if (!_levelButtons[i].TryGetComponent<Image>(out Image image)) return;
                image.color = _lockedColor;
                if (!_levelButtons[i].TryGetComponent<Button>(out Button button)) return;
                button.enabled = false;
            }
        }
    }

    public void UnlockAllLevel()
    {
        _playerData.UnlockedLevel = 3;
        UpdateLevelButtonState();
    }
}
