using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundData", menuName = "ScriptableObject/BackgroundDataScriptableObject")]
[Serializable]
public class BackgroundDataScriptableObject : ScriptableObject
{
    public float bgData1;
    public float bgData2;

    private float _defaultBgData1;
    private float _defaultBgData2;

    private void OnEnable()
    {
        _defaultBgData1 = bgData1;
        _defaultBgData2 = bgData2;
    }

    private void OnDisable()
    {
        bgData1 = _defaultBgData1;
        bgData2 = _defaultBgData2;
    }
}
