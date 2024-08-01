using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private void Awake()
    {
        _slider.minValue = 0.0001f;
        _slider.maxValue = 1.0f;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        float convertedVolume = ConvertLinearToLog(volume);

        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, convertedVolume);
    }

    private float ConvertLinearToLog(float value)
    {
        float scalingRatio = 20f;

        return Mathf.Log10(value) * scalingRatio;
    }
}
