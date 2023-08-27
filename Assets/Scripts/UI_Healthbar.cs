using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class UI_Healthbar : MonoBehaviour
{
    [BoxGroup("Text Reference")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [BoxGroup("Image Component Reference")]
    [SerializeField] private Image _healthBarFill;

    public void OnChangeUIHealthBarFill(Component sender, object data)
    {
        if(data is int)
        {
            int amount = (int)data;
            _healthText.text = amount.ToString();
            _healthBarFill.fillAmount = (float)amount / 100;
        }
        
    }
}
