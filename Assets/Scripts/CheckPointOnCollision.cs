using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class CheckPointOnCollision : MonoBehaviour
{
    [BoxGroup("Component Reference")]
    [SerializeField] private SpriteRenderer _checkPointSpriteRenderer;
    [BoxGroup("Sprite Reference")]
    [SerializeField] private Sprite _activeCheckPointSprite;
    [BoxGroup("Script Reference")]
    [SerializeField] private ObjectId _objectsId;
    [BoxGroup("SO")]
    [SerializeField] private CollectiblesManager _checkPointsManager;
    [BoxGroup("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [BoxGroup("Event")]
    [SerializeField] private GameEventNoParam _onCollideCheckpointEvent;

    private void Start()
    {
        if (_checkPointsManager.IsCollected(_objectsId.id))
        {
            _checkPointSpriteRenderer.sprite = _activeCheckPointSprite;
            if (!TryGetComponent<BoxCollider2D>(out BoxCollider2D collider)) return;
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _checkPointSpriteRenderer.sprite = _activeCheckPointSprite;
            _checkPointsManager.CollectCollectible(_objectsId);
            _playerData.SpawnPointId = _objectsId.id+1;
            _onCollideCheckpointEvent.Raise();
            if (!TryGetComponent<BoxCollider2D>(out BoxCollider2D collider)) return;
            collider.enabled = false;
        }

    }
}
