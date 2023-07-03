using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinFailScript : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private AudioSource _clickAudio;

    void Start()
    {
        _score.text = PlayerPrefs.GetString("PlayerScore", "0");
    }

    public void SetLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ClickSound()
    {
        _clickAudio.Play();
    }
}
