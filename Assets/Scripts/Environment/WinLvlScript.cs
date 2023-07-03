using UnityEngine;
using UnityEngine.Playables;

public class WinLvlScript : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeline;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            _timeline.Play();
        }
    }
}