using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    public void OnStart(int ScenceIndex)
    {
        if (ScenceIndex != 4 || ScenceIndex != 5)
        {
            Application.Quit();
        }
        //������� ScenceIndex�������U��
        SceneManager.LoadScene(ScenceIndex);

    }
}
