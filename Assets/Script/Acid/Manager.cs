using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Dropdown dropdown;
    public static Manager instance;
    public float volume = 0f;
    public int titration_solution = 0;         // 0:KOH, 1: NaOH, 2:HCL 3:H2SO4
    public InputField titration_mole_text;
    public float titration_mole = 0.5f;
    public Text volume_text;
    private void Awake() {
        instance = this;    
    }

    void Update()
    {
        volume_text.text = volume.ToString();
        titration_mole = float.Parse(titration_mole_text.text);
        switch (dropdown.options[dropdown.value].text)
        {
            case "²B®ñ¤Æ¹[":
                titration_solution = 0;
                break;
            case "²B®ñ¤Æ¶u":
                titration_solution = 1;
                break;
            case "ÆQ»Ä":
                titration_solution = 2;
                break;
            case "²¸»Ä":
                titration_solution = 3;
                break;
        }
        print("Volume: " + volume);
        print("Mole: " + titration_mole);
        print("Solution: " + dropdown.options[dropdown.value].text);
        print("Solution: " + titration_solution);
    }

    public void Reset()
    {
        volume = 0;
        volume_text.text = volume.ToString();
        titration_mole_text.text = 0.5f.ToString();
        titration_mole = 0.5f;
    }
}
