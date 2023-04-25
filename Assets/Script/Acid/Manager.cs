using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Dropdown dropdown;
    public static Manager instance;
    public Liquid liquid_A;
    public Liquid liquid_B;
    public double volume;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public InputField titration_mole_text;
    public float titration_mole = 0.5f;
    public Text volume_text;
    public double pH_value = 7.0;
    public Image liquid_image;
    private void Awake() {
        instance = this;
        liquid_A = DataManager.liquid_A;
        volume = liquid_A.volume;
        SetupVolume();
    }
    
    public void SetupVolume()
    {
        volume_text.text = volume.ToString();
    }

    public void SetUpType()
    {
        switch (dropdown.value)
        {
            case 0:
                titration_solution = 0;
                break;
            case 1:
                titration_solution = 1;
                break;
            case 2:
                titration_solution = 2;
                break;
            case 3:
                titration_solution = 3;
                break;
        }
    }
    public void SetUpMole()
    {
        titration_mole = float.Parse(titration_mole_text.text);
    }
    public void Reset()
    {
        liquid_A = DataManager.liquid_A;
        volume = liquid_A.volume;
        volume_text.text = volume.ToString();
        titration_mole_text.text = 0.5f.ToString();
        titration_mole = 0.5f;
    }

    public void ChangeColor()
    {
        if(liquid_A.pH < 8.3)
        {
            liquid_image.color = Color.clear;
        }
        else if(liquid_A.pH > 10)
        {
            liquid_image.color = Color.magenta * 0.9f;
        }
    }
}
