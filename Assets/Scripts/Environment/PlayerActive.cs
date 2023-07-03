using UnityEngine;

public class PlayerActive : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public void Active()
    {
        _player.SetActive(true);
    }
}