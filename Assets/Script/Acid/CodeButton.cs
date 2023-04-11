using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeButton : MonoBehaviour
{
    public Dropdown solution_o;
    public InputField concentration_o;
    public InputField volume_o;
    public InputField output_text;

    public InputField decrypt_input;
    public InputField decrypt_output;
    private string source = "";
    public void GenerateCode()
    {
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
