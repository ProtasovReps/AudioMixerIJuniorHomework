using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _button.onClick.AddListener(_audioSource.Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_audioSource.Play);
    }
}
