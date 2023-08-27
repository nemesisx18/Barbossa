using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventNoParamListener : MonoBehaviour
{
    [SerializeField] private GameEventNoParam _gameEventNoParam;

    [SerializeField] private UnityEvent _responsesNoParam;

    private void OnEnable()
    {
        _gameEventNoParam.RegisterListener(this);
    }

    private void OnDisable()
    {
        _gameEventNoParam.UnregisterListener(this);
    }

    public void OnEventRaisedNoParam()
    {
        _responsesNoParam.Invoke();
    }
}
