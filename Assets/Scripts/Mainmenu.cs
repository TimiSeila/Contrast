using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SelectMap()
    {
        SceneManager.LoadScene(4);
    }

    public void SelectMap2()
    {
        SceneManager.LoadScene(5);
    }

    public void SelectMap3()
    {
        SceneManager.LoadScene(6);
    }
}
