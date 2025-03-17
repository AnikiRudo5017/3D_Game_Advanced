using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Finish;
    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void RestartBtn()
    {
        GameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitBtn()
    {
        SceneManager.LoadScene(0);
    }
}
