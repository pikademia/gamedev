using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] Slider sliderHP;

    public void DisplayHP(float hp)
    {
        sliderHP.value = hp;
    }
}
