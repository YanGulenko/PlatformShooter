using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLvlScript : MonoBehaviour
{
    public void EndLvl()
    {
        SceneManager.LoadScene(2);
    }
}