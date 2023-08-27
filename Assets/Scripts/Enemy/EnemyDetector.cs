using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class EnemyDetector : MonoBehaviour
{
    [BoxGroup("Event")]
    [SerializeField] GameEvent _onDetectPlayer;
    [BoxGroup("Event")]
    [SerializeField] GameEventNoParam _onGateClose;

    public Transform targetInDistance { get; private set; }

    private void Start()
    {
        targetInDistance = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetInDistance = collision.transform;
            _onDetectPlayer.Raise(this, collision.gameObject);
            if(_onGateClose != null) _onGateClose.Raise();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetInDistance = null;
        }
    }
}
