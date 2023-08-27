using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ObjectIdAssigner : MonoBehaviour
{
    [BoxGroup("All corresponding collectibles references")]
    [SerializeField] private ObjectId[] _objectsId;
    void Awake()
    {
        AssignID();
    }

    private void AssignID()
    {
        for (int i = 0; i < _objectsId.Length; i++)
        {
            _objectsId[i].id = i;
        }
    }
}
