using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public LiquidType solution { 
        get {
            return _solution;
        } 
        set
        {
            _solution = value;
            switch (_solution)
            {
                case LiquidType.KOH:
                case LiquidType.NaOH:
                    isAcid = false;
                    break;
                case LiquidType.HCL:
                case LiquidType.H2SO4:
                    isAcid = true;
                    break;
            }
            switch (_solution)
            {
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
    }
    private LiquidType _solution;
    public double concentration;
    public double volume;
    private bool isAcid;
    private int constant;
    public double pH {
        get {
            if(isAcid)
            {
                return Math.Log10(1 / (Math.Abs(concentration) * constant));
            }
            else{
                return 14-Math.Log10(1 / (Math.Abs(concentration) * constant));
            }
        }
    }
    public Liquid() {}
    public Liquid(LiquidType sol, double con, double vol)
    {
        solution = sol;
        concentration = con;
        volume = vol;
    }

    public Liquid(LiquidType sol) => new Liquid(sol, 0, 0);

    public Liquid (Liquid a) => new Liquid(a.solution, a.concentration, a.volume);
    // public static LiquidData operator +(LiquidData a) => a;
    public static Liquid operator +(Liquid a, Liquid b)
    {
        Debug.Log(a.solution);
        Debug.Log(a.concentration);
        Debug.Log(a.constant);
        Debug.Log(a.volume);
        Liquid mix;
        double mix_H;
        double a_H = (a.volume/1000) * a.concentration * a.constant;
        double b_H = (b.volume/1000) * b.concentration * b.constant;
        if(!a.isAcid) a_H = -a_H;
        if(!b.isAcid) b_H = -b_H;
        mix_H = a_H + b_H;

        if((mix_H > 0 && a.isAcid) || (mix_H < 0 && !a.isAcid))
        {
            mix = new Liquid(a);
            mix.constant = a.constant;
        }
        else
        {
            mix = new Liquid(b);
            mix.constant = b.constant;
        }
        Debug.Log(mix_H);
        Debug.Log(a_H);
        Debug.Log(b_H);

        mix.volume = a.volume + b.volume;
        Debug.Log(mix.volume);
        Debug.Log(a.volume);
        Debug.Log(b.volume);
        Debug.Log(mix.constant);
        mix.concentration = mix_H / (double)mix.constant / (mix.volume / 1000);
        Debug.Log(mix_H / (double)mix.constant);
        Debug.Log((mix.volume / 1000));

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


// tpKgD+SsLG9+rtAnGaUWjA==