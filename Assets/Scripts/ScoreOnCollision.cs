using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScoreOnCollision : MonoBehaviour
{
    [BoxGroup("Script Reference")]
    [SerializeField] private ObjectId _objectsId;
    [BoxGroup("SO")]
    [SerializeField] private CollectiblesManager _scoreCollectiblesManager;
    [BoxGroup("Event")]
    [SerializeField] private GameEvent _onCollectScoreEvent;
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollectCollectiblesEvent;
    [BoxGroup("Variable")]
    [SerializeField] private int _scoreValue = 100;

    private void Start()
    {
        if (_scoreCollectiblesManager.IsCollected(_objectsId.id))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _onCollectScoreEvent.Raise(this, _scoreValue);
            _onCollectCollectiblesEvent.Raise();
            gameObject.SetActive(false);
            _scoreCollectiblesManager.CollectCollectible(_objectsId);
        }
    }
}
