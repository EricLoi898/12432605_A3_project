using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void GotoMainScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GotoIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }
    public void GotoGuideScene()
    {
        SceneManager.LoadScene("Guide");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
