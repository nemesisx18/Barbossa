using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectibles Manager", menuName = "ScriptableObject/Collectibles Manager")]
[Serializable]
public class CollectiblesManager : ScriptableObject
{
    public ObjectId[] objectsId;

    private bool[] collectedStates;

    private void OnEnable()
    {
        collectedStates = new bool[objectsId.Length];
    }

    public bool IsCollected(int collectibleID)
    {
        return collectedStates[collectibleID];
    }

    public void CollectCollectible(ObjectId collectible)
    {
        collectedStates[collectible.id] = true;
    }

    public void ResetCollectedStates()
    {
        collectedStates = new bool[objectsId.Length];
    }
}