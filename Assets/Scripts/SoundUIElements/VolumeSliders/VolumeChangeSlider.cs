using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChangeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixer _audioMixer;
    
    private readonly float _minVolumeValue = -80f;
    private string _volumeParamName;    

    private void Awake()
    {
        if (TryGetComponent(out IExposedParam exposedParam))
            _volumeParamName = exposedParam.ParamName;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        float value;        

        if (volume != 0)        
            value = Mathf.Log10(volume) * 20;
        else        
            value = _minVolumeValue;        

        _audioMixer.SetFloat(_volumeParamName, value);
    }
}
