using UnityEngine;
using UnityEngine.Audio;

public class VolumeInitScript : MonoBehaviour
{
    [SerializeField] private string _volumeParametr = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;

    void Start()
    {
        float volumeValue = PlayerPrefs.GetFloat(_volumeParametr, 0f);
        _mixer.SetFloat(_volumeParametr, volumeValue);
    }
}