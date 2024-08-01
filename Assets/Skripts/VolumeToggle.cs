using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeToggle : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SwitchVolume);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SwitchVolume);
    }

    private void SwitchVolume(bool isOn) => AudioListener.pause = isOn == false;
}
