using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVolume: MonoBehaviour
{
    // Start is called before the first frame update
    public void addone()
    {
        Manager.instance.volume += 0.01f;
    }
    public void addten()
    {
        Manager.instance.volume += 0.1f;
    }
    public void addhundred()
    {
        Manager.instance.volume += 1f;
    }

}
