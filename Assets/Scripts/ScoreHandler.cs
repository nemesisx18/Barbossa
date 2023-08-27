using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private int _currentScore = 0;

    public void OnIncreaseScore(Component sender, object data)
    {
        if(data is int)
        {
            _currentScore += (int)data;
        }
    }
}
