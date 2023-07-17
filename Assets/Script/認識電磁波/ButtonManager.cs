using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public TMP_Text button2_text;
    public Button Button2;
    public bool counter2 = true;
    public TMP_Text button1_text;
    public Button Button1;
    public bool counter1 = true;
    // Start is called before the first frame update
    public void ChangeTextButton2()
    {
        ColorBlock Color2 = Button2.colors;
        if (counter2 == true)
        {
            button2_text.text = "°¾·¥¬] 2: ¶}";
            Color2.selectedColor = new Color(251, 255, 165, 255);
            Button2.colors = Color2;
            Debug.Log(Color2.selectedColor);
            counter2 = false;
        }
        else
        {
            button2_text.text = "°¾·¥¬] 2: Ãö";
            Color2.selectedColor = new Color(255, 255, 255, 255);
            Button2.colors = Color2;
            Debug.Log(Color2.selectedColor);
            counter2 = true;
        }
    }
    public void ChangeTextButton1()
    {
        ColorBlock Color1 = Button1.colors;
        if (counter1 == true)
        {
            button1_text.text = "°¾·¥¬] 1: ¶}";
            Color1.selectedColor = new Color(251, 255, 165, 255);
            Button1.colors = Color1;
            Debug.Log(Color1.selectedColor);
            counter1 = false;
        }
        else
        {
            button1_text.text = "°¾·¥¬] 1: Ãö";
            Color1.selectedColor = new Color(255, 255, 255, 255);
            Button1.colors = Color1;
            Debug.Log(Color1.selectedColor);
            counter1 = true;
        }
    }
}
