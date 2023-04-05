using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStart(int ScenceIndex)
    {
        if (ScenceIndex != 0 || ScenceIndex != 1 || ScenceIndex != 2 || ScenceIndex != 3)
        {
            Application.Quit();
        }
        //跳轉場景 ScenceIndex場景的下標
        SceneManager.LoadScene(ScenceIndex);

    }
}
