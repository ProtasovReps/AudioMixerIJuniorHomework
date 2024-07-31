using UnityEngine;
using UnityEngine.Audio;

public class SoundPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string BackgroundVolume = nameof(BackgroundVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    private float _lastVolume;
    private float _disabledVolumeValue = -80f;

    private void Awake() => _lastVolume = 0;

    public void ToggleSound(bool isEnabled)
    {
        if (isEnabled)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, _lastVolume);
        }
        else
        {
            _mixer.audioMixer.GetFloat(MasterVolume, out _lastVolume);
            _mixer.audioMixer.SetFloat(MasterVolume, _disabledVolumeValue);
        }
    }

    public void SetMasterVolume(float volume) => SetVolume(MasterVolume, volume);

    public void SetButtonsVolume(float volume) => SetVolume(ButtonsVolume, volume);
    
    public void SetBackgroundVolume(float volume) => SetVolume(BackgroundVolume, volume);

    private void SetVolume(string groupName, float volume)
    {
        float convertedVolume = ConvertLinearToLog(volume);

        _mixer.audioMixer.SetFloat(groupName, convertedVolume);
    }

    private float ConvertLinearToLog(float value)
    {
        float scalingRatio = 20f;

        return Mathf.Log10(value) * scalingRatio;
    }
}