using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject _MenuWindow;
    [SerializeField] private AudioSource _clickAudio;
    private GameObject _currentWindow;

    private void Awake()
    {
        _currentWindow = _MenuWindow;
        _currentWindow.SetActive(true);
    }

    public void ChangeWindow(GameObject nextWindow)
    {
        if (_currentWindow != null)
        {
            _currentWindow.SetActive(false);
            nextWindow.SetActive(true);
            _currentWindow = nextWindow;
        }
    }

    public void SetLvl(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Click()
    {
        _clickAudio.Play();
    }

    public void Exit()
    {
        Application.Quit();
    }
}