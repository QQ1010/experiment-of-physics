using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Dropdown dropdown;
    public static Manager instance;
    public LiquidData data;
    public float volume;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public InputField titration_mole_text;
    public float titration_mole = 0.5f;
    public Text volume_text;
    private void Awake() {
        instance = this;
        data = DataManager.data;
        volume = data.volume;
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
        data = DataManager.data;
        volume = data.volume;
        volume_text.text = volume.ToString();
        titration_mole_text.text = 0.5f.ToString();
        titration_mole = 0.5f;
    }
}
