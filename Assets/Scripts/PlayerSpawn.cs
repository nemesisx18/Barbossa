using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerSpawn : MonoBehaviour
{
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Spawn Points")]
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if(i == _playerData.SpawnPointId)
            {
                transform.position = _spawnPoints[i].position;
            }
            
        }
        
    }
}
