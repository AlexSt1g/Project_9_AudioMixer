using UnityEngine;

[RequireComponent(typeof(VolumeChangeSlider))]
public class MusicVolumeSlider : MonoBehaviour, IExposedParam
{
    private const string MusicVolume = nameof(MusicVolume);

    public string ParamName => MusicVolume;
}
