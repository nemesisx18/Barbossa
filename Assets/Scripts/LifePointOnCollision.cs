using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LifePointOnCollision : MonoBehaviour
{
    [BoxGroup("Script Reference")]
    [SerializeField] private ObjectId _objectsId;
    [BoxGroup("SO")]
    [SerializeField] private CollectiblesManager _lpCollectiblesManager;
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollectLifePointEvent,_onCollectCollectiblesEvent;

    private void Start()
    {
        if (_lpCollectiblesManager.IsCollected(_objectsId.id))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth)) return;
            _onCollectLifePointEvent.Raise();
            _onCollectCollectiblesEvent.Raise();
            gameObject.SetActive(false);
            _lpCollectiblesManager.CollectCollectible(_objectsId);
        }
        
    }
}
