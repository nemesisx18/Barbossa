using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeData : MonoBehaviour
{
    [SerializeField] BackgroundDataScriptableObject _bgData;
    [SerializeField] PlayerDataScriptableObject _playerData;
    void Start()
    {
        _bgData.bgData1 = 0;
        _bgData.bgData2 = 38.4f;
        _playerData.ResetData();
    }

}
