using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public TMP_Text button_text;
    public Button Button;
    public bool counter = true;
    public string txt_true;
    public string txt_false;
    public void ChangeTextButton()
    {
        ColorBlock buttoncolor = Button.colors;
        if (counter == true)
        {
            button_text.text = txt_true;
            buttoncolor.normalColor = Color.yellow;
            buttoncolor.selectedColor = Color.yellow;
            buttoncolor.pressedColor = Color.yellow;
            Button.colors = buttoncolor;
            counter = false;
        }
        else
        {
            button_text.text = txt_false;
            buttoncolor.normalColor = Color.white;
            buttoncolor.selectedColor = Color.white;
            buttoncolor.pressedColor = Color.white;
            Button.colors = buttoncolor;
            counter = true;
        }
    }
    //public void ChangeTextButton1()
    //{
    //    ColorBlock Color1 = Button1.colors;
    //    if (counter1 == true)
    //    {
    //        button1_text.text = "°¾·¥¬] 1: ¶}";
    //        Color1.normalColor = Color.yellow;
    //        Color1.selectedColor = Color.yellow;
    //        Color1.pressedColor = Color.yellow;
    //        Button1.colors = Color1;
    //        Debug.Log(Color1.selectedColor);
    //        counter1 = false;
    //    }
    //    else
    //    {
    //        button1_text.text = "°¾·¥¬] 1: Ãö";
    //        Color1.normalColor = Color.white;
    //        Color1.selectedColor = Color.white;
    //        Color1.pressedColor = Color.white;
    //        Button1.colors = Color1;
    //        counter1 = true;
    //    }
    //}
}
