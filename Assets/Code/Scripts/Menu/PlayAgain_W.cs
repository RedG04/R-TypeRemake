using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain_W : MonoBehaviour
{
    public void PlayGame()
    {
        //if (Application.isPlaying) gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        Debug.Log("play");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
