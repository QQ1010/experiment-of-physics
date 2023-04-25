using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Manager : MonoBehaviour
{
    public Dropdown titrantion_dropdown;
    public static Manager instance;
    public LiquidData data;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public double titration_concentration = 0.5;
    public InputField titration_concentration_text;
    public double volume;
    public Text volume_text;
    public double H_mole;
    public double OH_mole;
    bool titrantion_H = false;
    bool liquid_H = false;
    double pH = 7;
    public Text PH;
    private void Awake() {
        instance = this;
        data = DataManager.data;
        volume = data.volume;
        switch (data.solution)
        {
            case 0:
                H_mole = 0;
                OH_mole = data.concentration * (data.volume / 1000);
                break;
            case 1:
                H_mole = 0;
                OH_mole = data.concentration * (data.volume / 1000);
                break;
            case 2:
                H_mole = data.concentration * (data.volume / 1000);
                OH_mole = 0;
                liquid_H = true;
                break;
            case 3:
                H_mole = data.concentration * (data.volume / 1000) * 2;
                OH_mole = 0;
                liquid_H = true;
                break;
        }
        SetupVolume();
    }

    public void addvolume(float add_volume)
    {
        volume += add_volume;
        double H_mole_add = 0d;
        double OH_mole_add = 0d;
        switch (titrantion_dropdown.value)
        {
            case 0:
                H_mole_add = 0;
                OH_mole_add = titration_concentration * (add_volume / 1000);
                break;
            case 1:
                H_mole_add = 0;
                OH_mole_add = titration_concentration * (add_volume / 1000);
                break;
            case 2:
                H_mole_add = titration_concentration * (add_volume / 1000);
                OH_mole_add = 0;
                titrantion_H = true;
                break;
            case 3:
                H_mole_add = titration_concentration * (add_volume / 1000) * 2;
                OH_mole_add = 0;
                titrantion_H = true;
                break;
        }
        print(titrantion_H);
        print(liquid_H);
        print(volume);
        print(H_mole);
        print(OH_mole);
        if (titrantion_H & liquid_H)
        {
            H_mole += H_mole_add;
            if (H_mole < (1e-7))
            {
                pH = -Math.Log((H_mole + 1e-7) / volume);
            }
            else
            {
                pH = -Math.Log(H_mole / volume);
            }
        }
        else if(!titrantion_H & !liquid_H)
        {
            OH_mole += OH_mole_add;
            if (OH_mole < (1e-7))
            {
                pH = 14 - (-Math.Log((OH_mole + 1e-7) / volume));
            }
            else
            {
                pH = 14 - (-Math.Log(OH_mole / volume));
            }
        }
        else if (titrantion_H & !liquid_H)
        {
            OH_mole -= H_mole_add;
            //H_mole += H_mole_add;
            if (OH_mole < 0)
            {
                H_mole = -OH_mole;
                if (H_mole < (1e-7))
                {
                    pH = Math.Log((H_mole + 1e-7) / volume);
                }
                else
                {
                    pH = Math.Log((H_mole) / volume);
                }
            }
            else if (OH_mole == 0)
            {
                pH = 7;
            }
            else
            {
                if (OH_mole < (1e-7))
                {
                    pH = 14 - Math.Log((OH_mole + 1e-7) / volume);
                }
                else
                {
                    pH = 14 - Math.Log((OH_mole) / volume);
                }
            }
        }
        else if (!titrantion_H & liquid_H)
        {
            H_mole -= OH_mole_add;
            if (H_mole < 0)
            {
                OH_mole = -H_mole;
                if (OH_mole < (1e-7))
                {
                    pH = 14 - Math.Log((OH_mole + 1e-7) / volume);
                }
                else
                {
                    pH = 14 - Math.Log((OH_mole) / volume);
                }
            }
            else if(H_mole == 0)
            {
                pH = 7;
            }
            else
            {
                if (H_mole < (1e-7))
                {
                    pH = Math.Log((H_mole + 1e-7) / volume);
                }
                else
                {
                    pH = Math.Log((H_mole) / volume);
                }
            }
        }
        PH.text = Math.Round(pH,4).ToString();
        print("pH = " + pH);
    }

    

    public void SetupVolume()
    {
        volume_text.text = Math.Round(volume,2).ToString();
    }

    public void SetUpType()
    {
        switch (titrantion_dropdown.value)
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
        titration_concentration = float.Parse(titration_concentration_text.text);
    }
    public void Reset()
    {
        data = DataManager.data;
        volume = data.volume;
        volume_text.text = volume.ToString();
        titration_concentration_text.text = 0.5f.ToString();
        titration_concentration = 0.5f;
    }
}


//tpKgD + SsLG9 + rtAnGaUWjA ==