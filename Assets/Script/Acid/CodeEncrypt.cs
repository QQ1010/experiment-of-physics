using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CodeEncrypt : MonoBehaviour
{
    // public InputField output_text;
    static private readonly string CryptoKey = "1234567890123456";
    static public string Encrypt(string SourceStr)
    {
        string encrypt = "";
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
        byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
        byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
        aes.Key = key;
        aes.IV = iv;

        byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
        using (MemoryStream ms = new MemoryStream())
        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(dataByteArray, 0, dataByteArray.Length);
            cs.FlushFinalBlock();
            encrypt = Convert.ToBase64String(ms.ToArray());
        }
        return encrypt;
        // print(encrypt);
        // output_text.text = encrypt;
    }
    static public string Decrypt(string SourceStr)
    {
        string decrypt = "";
        
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
        byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
        byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
        aes.Key = key;
        aes.IV = iv;

        byte[] dataByteArray = Convert.FromBase64String(SourceStr);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                decrypt = Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        return decrypt;
        // output_text.text = decrypt;
    }

}
