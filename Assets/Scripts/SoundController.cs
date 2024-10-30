using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string SoundEffectsVolume = nameof(SoundEffectsVolume);
    private const string MusicVolume = nameof(MusicVolume);

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _soundEffectsVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Toggle _muteToggle;
    
    private readonly float _sliderMinValue = 0.0001f;
    private readonly float _sliderMaxValue = 1f;
    private readonly float _minVolumeValue = -80f;
    private readonly float _maxVolumeValue = 0f;

    private void Awake()
    {
        SetSliderValues(_masterVolumeSlider);
        SetSliderValues(_soundEffectsVolumeSlider);
        SetSliderValues(_musicVolumeSlider);
        _muteToggle.isOn = false;
    }

    private void OnEnable()
    {
        _masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _soundEffectsVolumeSlider.onValueChanged.AddListener(ChangeSFXVolume);
        _musicVolumeSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _muteToggle.onValueChanged.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _masterVolumeSlider.onValueChanged.RemoveListener(ChangeMasterVolume);
        _soundEffectsVolumeSlider.onValueChanged.RemoveListener(ChangeSFXVolume);
        _musicVolumeSlider.onValueChanged.RemoveListener(ChangeMusicVolume);
        _muteToggle.onValueChanged.RemoveListener(MuteSound);
    }

    private void MuteSound(bool isOn)
    {
        if (isOn)
            _audioMixer.SetFloat(MasterVolume, _minVolumeValue);
        else
            _audioMixer.SetFloat(MasterVolume, _maxVolumeValue);
    }

    private void ChangeMasterVolume(float volume)
    {
        ChangeVolume(MasterVolume, volume);
    }

    private void ChangeSFXVolume(float volume)
    {
        ChangeVolume(SoundEffectsVolume, volume);
    }

    private void ChangeMusicVolume(float volume)
    {
        ChangeVolume(MusicVolume, volume);
    }

    private void ChangeVolume(string paramName, float volume)
    {
        _audioMixer.SetFloat(paramName, Mathf.Log10(volume) * 20);
    }

    private void SetSliderValues(Slider slider)
    {
        if (slider != null)
        {
            slider.minValue = _sliderMinValue;
            slider.maxValue = _sliderMaxValue;
        }
        else
        {
            throw new ArgumentNullException(nameof(slider));
        }
    }
}
