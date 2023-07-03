using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private GameObject _player;
    [SerializeField] private Text _currentScore;
    private bool _isPause;
    private GameObject _currentWindow;

    private void Awake()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        _isPause = false;
        _currentWindow = _pauseWindow;
        _currentWindow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Cancel") && _currentWindow == _pauseWindow)
        {
            Pause();
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetString("PlayerScore", _currentScore.text);
        Cursor.visible = true;
    }

    public void Pause()
    {
        if (!_isPause)
        {
            _isPause = true;
            _pauseWindow.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            _player.GetComponent<PlayerInput>().enabled = false;
        }
        else
        {
            _isPause = false;
            _pauseWindow.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            _player.GetComponent<PlayerInput>().enabled = true;
        }
    }

    public void WindowChange(GameObject nextWindow)
    {
        if (_currentWindow != null)
        {
            _currentWindow.SetActive(false);
            nextWindow.SetActive(true);
            _currentWindow = nextWindow;
        }
    }

    public void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ClickSound()
    {
        _clickSound.Play();
    }
}