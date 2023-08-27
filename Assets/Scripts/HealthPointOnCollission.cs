using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ObjectId))]
public class HealthPointOnCollission : MonoBehaviour
{
    [BoxGroup("Script Reference")]
    [SerializeField] private ObjectId _objectsId;
    [BoxGroup("SO")]
    [SerializeField] private CollectiblesManager _hpCollectiblesManager;
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollectCollectiblesEvent;
    [BoxGroup("Variables")]
    [SerializeField] private int _healValue = 100;

    private void Start()
    {
        if (_hpCollectiblesManager.IsCollected(_objectsId.id))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth)) return;
            playerHealth.Heal(_healValue);
            _onCollectCollectiblesEvent.Raise();
            gameObject.SetActive(false);
            _hpCollectiblesManager.CollectCollectible(_objectsId);
        }
    }
}
