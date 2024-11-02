using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    [SerializeField] private Toggle _muteToggle;

    private void Awake()
    {
        _muteToggle.isOn = false;
    }

    private void OnEnable()
    {
        _muteToggle.onValueChanged.AddListener(MuteSound);
    }

    private void OnDisable()
    {
        _muteToggle.onValueChanged.RemoveListener(MuteSound);
    }

    private void MuteSound(bool isOn)
    {
        AudioListener.volume = isOn ? 0 : 1;
    }
}
