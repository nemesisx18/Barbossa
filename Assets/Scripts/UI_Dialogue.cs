using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class UI_Dialogue : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private UI_Cutscene _cutscene;
    [SerializeField] private SceneHandler _scene;
    [SerializeField] private float _textSpeed;
    

    [SerializeField] private bool isEpilog;
    [ShowIf("isEpilog")]
    [SerializeField] UI_Transisiton _transition2;

    private int _index;
    private bool _canClick;

    void Start()
    {
        Time.timeScale = 1;
        _canClick = true;
        _textComponent.text = string.Empty;
        StartDialogue();
    }

    private void StartDialogue()
    {
        _index = 0;
        StartCoroutine(TypeLine());
        Debug.Log("Dialogue Start");
    }

    IEnumerator TypeLine()
    {
        Debug.Log("Type Dialogue..");
        foreach (char c in lines[_index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
        if(_index < lines.Length - 1)
        {
            _index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_canClick) return;
        if(_textComponent.text == lines[_index])
        {
            NextLine();
            _cutscene.NextCutscene(_index);

            if (_index == lines.Length - 1)
            {
                if (isEpilog)
                {
                    _canClick = false;
                    StartCoroutine(ToTransitionOnDelay());
                }
            }
        }
        else
        {
            StopAllCoroutines();
            _textComponent.text = lines[_index];

            if (_index != lines.Length - 1) return;
            if (isEpilog)
            {
                _canClick = false;
                StartCoroutine(ToTransitionOnDelay());
            }
            else
            {
                _canClick = false;
                StartCoroutine(ToGameSceneOnDelay());
            }

        }
    }

    IEnumerator ToGameSceneOnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        //_scene.OnDemandScenePlay();
        _scene.OnNextLevel();
    }

    IEnumerator ToTransitionOnDelay()
    {
        yield return new WaitForSeconds(2.5f);
        _transition2.gameObject.SetActive(true);
        _transition2.BeginTransition();
    }
}
