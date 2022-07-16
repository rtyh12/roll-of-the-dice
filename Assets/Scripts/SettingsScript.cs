using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetMusicVolume (float musicVolume)
    {
        audioMixer.SetFloat("musicParam", musicVolume);
    }

    public void SetEffectsVolume (float effectsVolume)
    {
        audioMixer.SetFloat("effectsParam", effectsVolume);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
