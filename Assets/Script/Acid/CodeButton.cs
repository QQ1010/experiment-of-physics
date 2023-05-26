using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CodeButton : MonoBehaviour
{
    public TMP_Dropdown solution_o;
    public TMP_InputField concentration_o;
    public TMP_InputField volume_o;
    public TMP_InputField output_text;

    public TMP_InputField decrypt_input;
    public TMP_InputField decrypt_output;
    private string source = "";
    public void GenerateCode()
    {
        float volume = float.Parse(volume_o.text);
        if (volume > 125)
            volume = 125;
        volume_o.text = Math.Round(volume, 2).ToString();
        source = "";
        source += solution_o.value.ToString() + " ";
        source += concentration_o.text + " ";
        source += volume_o.text + " ";
        output_text.text = CodeEncrypt.Encrypt(source);
    }

    public void DecryptCode()
    {
        if(decrypt_output)
            decrypt_output.text = CodeEncrypt.Decrypt(decrypt_input.text);
        DataManager.ParseData(CodeEncrypt.Decrypt(decrypt_input.text));
    }
}
