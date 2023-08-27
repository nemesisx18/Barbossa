using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    [BoxGroup("SO")]
    [SerializeField] private BackgroundDataScriptableObject _bgData;
    [BoxGroup("Transform Reference")]
    [SerializeField] private Transform _mainCam,_bg1, _bg2;
    [BoxGroup("Variables")]
    [SerializeField] private float _length;

    private Transform temp;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On Scene Load Set BG Pos");
        _bg1.position = new Vector3(_bgData.bgData1, _bg1.position.y, _bg1.position.z);
        _bg2.position = new Vector3(_bgData.bgData2, _bg2.position.y, _bg2.position.z);
    }

    private void Awake()
    {
        //_bg1.position = new Vector3(_bgData.bgData1,_bg1.position.y,_bg1.position.z);
        //_bg2.position = new Vector3(_bgData.bgData2, _bg2.position.y, _bg2.position.z);
    }

    private void Update()
    {

        if(_mainCam.position.x > _bg1.position.x)
        {
            _bg2.position = _bg1.position + Vector3.right * _length;
        }

        if (_mainCam.position.x < _bg1.position.x)
        {
            _bg2.position = _bg1.position + Vector3.left * _length;
        }

        if(_mainCam.position.x > _bg2.position.x || _mainCam.position.x < _bg2.position.x)
        {
            temp = _bg1;
            _bg1 = _bg2;
            _bg2 = temp;
        }
    }

    public void OnCheckpointSaveBGData()
    {
        _bgData.bgData1 = _bg1.position.x;
        _bgData.bgData2 = _bg2.position.x;
    }

    public void OnResetSaveBGData()
    {
        Debug.Log("Reset BG Data");
        _bgData.bgData1 = 0;
        _bgData.bgData2 = _length;
    }
}
