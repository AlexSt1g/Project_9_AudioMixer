using UnityEngine;

[RequireComponent(typeof(VolumeChangeSlider))]
public class MasterVolumeSlider : MonoBehaviour, IExposedParam
{
    private const string MasterVolume = nameof(MasterVolume);
    
    public string ParamName => MasterVolume;
}
