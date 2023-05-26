using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class Manager : MonoBehaviour
{
    public TMP_Dropdown titrantion_dropdown;
    public static Manager instance;
    public Liquid liquid_A;
    public Liquid liquid_B;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public double titration_concentration = 0.5;
    public TMP_InputField titration_concentration_text;
    public TMP_Text volume_text;
    public TMP_Text PH;
    [SerializeField] private GameObject pinkLiquid, nocolorLiquid;
    private void Awake()
    {
        instance = this;
        liquid_A = DataManager.liquid_A;
        PH.text = Math.Round(liquid_A.pH, 2).ToString();
        liquid_B = new Liquid((LiquidType)titrantion_dropdown.value);
        SetupVolume();
        SetUpType();
        SetUpMole();
        ChangeColor();
        }

    public void addvolume(float add_volume)
    {
        liquid_B.volume = add_volume;
        if (liquid_A.volume + liquid_B.volume > 250)
            return;
        liquid_A += liquid_B;
        PH.text = Math.Round(liquid_A.pH, 2).ToString();
        print("pH = " + PH.text);
        ChangeColor();
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
        PH.text = Math.Round(liquid_A.pH, 2).ToString();
        titration_concentration_text.text = "0.5";
        titration_concentration = 0.5f;
        SetupVolume();
        SetUpType();
        SetUpMole();
        ChangeColor();
        }

    public void ChangeColor()
    {
        print(liquid_A.pH);
        if (liquid_A.pH < 8.3)
        {
            nocolorLiquid.SetActive(true);
            pinkLiquid.SetActive(false);
        }
        else if (liquid_A.pH > 10)
        {
            nocolorLiquid.SetActive(false);
            pinkLiquid.SetActive(true);
        }
    }
}
