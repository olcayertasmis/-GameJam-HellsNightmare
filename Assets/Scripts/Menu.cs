using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Menu : MonoBehaviour
{

    //public AudioSource musicSource, sfxSource;
    //public Slider musicVolumeSlider, sfxVolumeSlider;
    //public float musicVolume;
    public GameObject settings;
    public AudioMixer music;


    public void Play(string Menu)
    {
        SceneManager.LoadScene("Scene2");
    }

    public void Exit()
    {
        Application.Quit();
    }

    /*public void OnMusicVolumeChange()
    {
        musicSource.volume = musicVolumeSlider.value;
        sfxSource.volume = musicVolumeSlider.value;
    }*/

    /*void OnEnable()
    {
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });

    }*/
    public void SetMusicSound(float soundLevel)
    {
        music.SetFloat("music", Mathf.Log10(soundLevel) * 20);
    }
    public void SetSound(float soundLevel)
    {
        music.SetFloat("fx", Mathf.Log10(soundLevel) * 20);
    }
}



