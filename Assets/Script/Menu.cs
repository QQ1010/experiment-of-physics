using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStart(int ScenceIndex)
    {
        if (ScenceIndex == 4)
        {
            Application.Quit();
        }
        //������� ScenceIndex�������U��
        SceneManager.LoadScene(ScenceIndex);

    }
}
