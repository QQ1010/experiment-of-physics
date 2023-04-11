using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LiquidData
{
    public int solution;
    public float concentration;
    public float volume;
}

public class DataManager : MonoBehaviour
{
    [SerializeField]
    static public LiquidData data = new LiquidData();
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    static public void ParseData(string source)
    {
        string[] parts = source.Split(" ");
        if(parts.Length != 4) {
            foreach (string part in parts)
                print(part);
            print(parts.Length);
            throw new ArgumentException("Invalid source");
        }
        data.solution = Int32.Parse(parts[0]);
        data.concentration = float.Parse(parts[1]);
        data.volume = float.Parse(parts[2]);
        print(string.Format("{0}, {1}, {2}", data.solution, data.concentration, data.volume));
    }
}
