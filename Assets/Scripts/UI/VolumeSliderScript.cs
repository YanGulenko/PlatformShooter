using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderScript : MonoBehaviour
{
    [SerializeField] private string _volumeParametr = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;
    private Slider _slider;
    private const float _multiplier = 20f;
    private float _volumeValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        _mixer.SetFloat(_volumeParametr, _volumeValue);
    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(_volumeParametr, Mathf.Log10(_slider.value) * _multiplier);
        _slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParametr, _volumeValue);
    }
}