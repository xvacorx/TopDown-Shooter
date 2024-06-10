using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI lifeText;

    private void Update()
    {
        if (PlayerManager.Instance != null)
        {
            float playerHP = PlayerManager.Instance.hP;
            slider.value = playerHP;
            lifeText.text = playerHP.ToString() + "%";
        }
        else
        {
            slider.value = 0;
            lifeText.text = "0" + "%";
        }
    }
}