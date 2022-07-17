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
        audioMixer.SetFloat("musicParam", Mathf.Log10(musicVolume) * 20);
    }

    public void SetEffectsVolume (float effectsVolume)
    {
        audioMixer.SetFloat("effectsParam", Mathf.Log10(effectsVolume) * 20);
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
