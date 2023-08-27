using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DataHandler : MonoBehaviour
{
    [BoxGroup("Collectible Managers Reference")]
    [SerializeField] private CollectiblesManager[] _collectibleManagers;
    [BoxGroup("Player Data Reference")]
    [SerializeField] private PlayerDataScriptableObject _playerData;

    public void ResetColletibleData()
    {
        foreach(CollectiblesManager collectible in _collectibleManagers)
        {
            collectible.ResetCollectedStates();
        }
    }

    public void ResetSpawnData()
    {
        _playerData.NextLevelData();
    }
}
