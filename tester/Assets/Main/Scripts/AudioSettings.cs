using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;

    void Start()
    {
        // Загружаем сохранённую громкость
        float volume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        volumeSlider.value = volume;
        musicSource.volume = volume;

        // Подписка на изменение
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        musicSource.volume = value;

        // Сохраняем
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }
}
