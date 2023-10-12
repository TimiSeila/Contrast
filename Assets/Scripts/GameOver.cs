using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
