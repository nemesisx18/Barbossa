using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "ScriptableObject/PlayerDataScriptableObject")]
[Serializable]
public class PlayerDataScriptableObject : ScriptableObject
{
    [SerializeField] private int _totalLifePoint;
    public int TotalLifePoint
    {
        get
        {
            return _totalLifePoint;
        }

        set
        {
            _totalLifePoint = value;
            if (_totalLifePoint <= 0) _totalLifePoint = 0;
            if (_totalLifePoint > 3) _totalLifePoint = 3;
        }
    }

    [SerializeField] private int _totalScore;
    public int TotalScore
    {
        get
        {
            return _totalScore;
        }

        set
        {
            _totalScore = value;
            if (_totalScore <= 0) _totalScore = 0;
        }
    }
    [SerializeField] private int _spawnPointId;
    public int SpawnPointId
    {
        get
        {
            return _spawnPointId;
        }

        set
        {
            _spawnPointId = value;
            if (_spawnPointId <= 0) _spawnPointId = 0;
        }
    }

    [SerializeField] private int _unlockedLevel;
    public int UnlockedLevel
    {
        get
        {
            return _unlockedLevel;
        }

        set
        {
            _unlockedLevel = value;
            if (_unlockedLevel <= 1) _unlockedLevel = 1;
            if (_unlockedLevel > 3) _unlockedLevel = 3;
        }
    }

    private int _defaultLifePointTotal;
    private int _defaultTotalScore;
    private int _defaultSpawnPointId;

    public bool _isSFXOff;
    public bool _isBGMOff;

    private bool _defaultSFXState;
    private bool _defaultBGMState;

    private void Awake()
    {
        UnlockedLevel = PlayerPrefs.GetInt("SavedLevel");
    }

    private void OnEnable()
    {
        _defaultSFXState = _isSFXOff;
        _defaultBGMState = _isBGMOff;
        _defaultLifePointTotal = TotalLifePoint;
        _defaultTotalScore = TotalScore;
        _defaultSpawnPointId = SpawnPointId;
    }

    private void OnDisable()
    {
        _isSFXOff = _defaultSFXState;
        _isBGMOff = _defaultBGMState; 
        TotalLifePoint = _defaultLifePointTotal;
        TotalScore = _defaultTotalScore;
        SpawnPointId = _defaultSpawnPointId;
    }

    public void ResetData()
    {
        TotalLifePoint = _defaultLifePointTotal;
        TotalScore = _defaultTotalScore;
        SpawnPointId = _defaultSpawnPointId;
    }

    public void NextLevelData()
    {
        SpawnPointId = _defaultSpawnPointId;
    }

}
