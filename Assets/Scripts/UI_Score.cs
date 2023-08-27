using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class UI_Score : MonoBehaviour
{
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Text Reference")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [BoxGroup("Variable")]
    [SerializeField] private int _currentScore = 0;

    private void Start()
    {
        _currentScore = _playerData.TotalScore;
        _scoreText.text = $"Point: {_currentScore}";
    }

    public void OnChangeScoreText(Component sender, object data)
    {
        if (data is int)
        {
            _currentScore += (int)data;
            _playerData.TotalScore = _currentScore;
            _scoreText.text = $"Point: {_currentScore}";
        }
    }
}
