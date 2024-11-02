using UnityEngine;

[RequireComponent(typeof(VolumeChangeSlider))]
public class SoundEffectsVolumeSlider : MonoBehaviour, IExposedParam
{
    private const string SoundEffectsVolume = nameof(SoundEffectsVolume);

    public string ParamName => SoundEffectsVolume;
}
