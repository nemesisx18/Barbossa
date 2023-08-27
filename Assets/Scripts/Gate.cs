using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BoxCollider2D))]
public class Gate : MonoBehaviour
{
    [BoxGroup("Transform Reference")]
    [SerializeField] private Transform _gate, _finalPos;

    public void OnGateClosed()
    {
        if (!TryGetComponent<BoxCollider2D>(out BoxCollider2D collider)) return;
        collider.enabled = true;
        _gate.DOMoveY(_finalPos.position.y, 0.2f);
    }
}
