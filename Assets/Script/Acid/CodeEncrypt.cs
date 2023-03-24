using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using UnityEngine;
using TMPro;


public class CodeEncrypt : MonoBehaviour
{
    public TMP_InputField output_text;
    private readonly string CryptoKey = "1234567890123456";
    public void Encrypt(string SourceStr)
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
        print(encrypt);
        output_text.text = encrypt;
    }
    public void Decrypt(string SourceStr)
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
        output_text.text = decrypt;
    }
}
