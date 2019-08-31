using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("scene1");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
