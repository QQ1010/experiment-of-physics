using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderManager : MonoBehaviour
{
    public TMP_Text slider_text;
    public Slider Slider;

    private void Update()
    {
        slider_text.text = Slider.value.ToString("0.0");
    }
}
