using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UI_Cutscene : MonoBehaviour
{
    [SerializeField] Sprite[] _cutsceneSprites;

    public void NextCutscene(int index)
    {
        if (!TryGetComponent<Image>(out Image cutscene)) return;
        cutscene.sprite = _cutsceneSprites[index];
    }
}
