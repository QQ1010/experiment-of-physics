using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LiquidType{
    KOH,
    NaOH,
    HCL,
    H2SO4,
    Other
}


[System.Serializable]
public class Liquid
{
    public LiquidType solution;
    public double concentration;
    public double volume;
    private bool isAcid;
    private int constant;
    public double pH {
        get {
            if(isAcid)
            {
                return Math.Log10(1 / (concentration * constant));
            }
            else{
                return 14-Math.Log10(1 / (concentration * constant));
            }
        }
    }
    public Liquid() {}
    public Liquid(LiquidType sol, double con, double vol)
    {
        solution = sol;
        concentration = con;
        volume = vol;
        switch(sol) {
            case LiquidType.KOH:
            case LiquidType.NaOH:
                isAcid = false;
                break;
            case LiquidType.HCL:
            case LiquidType.H2SO4:
                isAcid = true;
                break;
        }
        switch(sol) {
            case LiquidType.KOH:
            case LiquidType.NaOH:
            case LiquidType.HCL:
                constant = 1;
                break;
            case LiquidType.H2SO4:
                constant = 2;
                break;
        }
    }
    public Liquid (Liquid a) => new Liquid(a.solution, a.concentration, a.volume);
    // public static LiquidData operator +(LiquidData a) => a;
    public static Liquid operator +(Liquid a, Liquid b)
    {
        Liquid mix;
        double mix_H;
        double a_H = (a.volume/1000) * a.concentration * a.constant;
        double b_H = (b.volume/1000) * b.concentration * b.constant;
        if(!a.isAcid) a_H = -a_H;
        if(!b.isAcid) b_H = -b_H;
        mix_H = a_H + b_H;

        if((mix_H > 0 && a.isAcid) || (mix_H < 0 && !a.isAcid))
            mix = new Liquid(a);
        else
            mix = new Liquid(b);
        
        mix.volume = a.volume + b.volume;
        mix.concentration = mix_H / (mix.volume*1000) / mix.constant;

        return mix;
    }

}

public class DataManager : MonoBehaviour
{
    [SerializeField]
    static public Liquid liquid_A = new Liquid();
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
        liquid_A.solution = (LiquidType)Int32.Parse(parts[0]);
        liquid_A.concentration = float.Parse(parts[1]);
        liquid_A.volume = float.Parse(parts[2]);
        print(string.Format("{0}, {1}, {2}", liquid_A.solution, liquid_A.concentration, liquid_A.volume));
    }
}
