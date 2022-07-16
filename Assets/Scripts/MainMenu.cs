using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Sphere");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
