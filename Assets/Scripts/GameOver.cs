using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
