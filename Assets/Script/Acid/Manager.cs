using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Manager : MonoBehaviour
{
    public Dropdown titrantion_dropdown;
    public static Manager instance;
    public Liquid liquid_A;
    public Liquid liquid_B;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public double titration_concentration = 0.5;
    public InputField titration_concentration_text;
    public Text volume_text;
    public Text PH;
    public Image liquid_image;
    private void Awake()
    {
        instance = this;
        liquid_A = DataManager.liquid_A;
        PH.text = Math.Round(liquid_A.pH, 4).ToString();
        liquid_B = new Liquid((LiquidType)titrantion_dropdown.value);
        SetupVolume();
        SetUpType();
        SetUpMole();
    }

    public void addvolume(float add_volume)
    {
        liquid_B.volume = add_volume;
        liquid_A += liquid_B;

        PH.text = Math.Round(liquid_A.pH, 4).ToString();
        print("pH = " + PH.text);
    }

    public void SetupVolume()
    {
        volume_text.text = Math.Round(liquid_A.volume, 2).ToString();
    }

    public void SetUpType()
    {
        liquid_B.solution = (LiquidType)titrantion_dropdown.value;
    }
    public void SetUpMole()
    {
        liquid_B.concentration = double.Parse(titration_concentration_text.text);
    }
    public void Reset()
    {
        liquid_A = DataManager.liquid_A;
        volume_text.text = liquid_A.volume.ToString();
        titration_concentration_text.text = "0.5";
        titration_concentration = 0.5f;
    }

    public void ChangeColor()
    {
        if (liquid_A.pH < 8.3)
        {
            liquid_image.color = Color.clear;
        }
        else if (liquid_A.pH > 10)
        {
            liquid_image.color = Color.magenta * 0.9f;
        }
    }
}
