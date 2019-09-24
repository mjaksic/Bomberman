using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Return()
    {
        FindObjectOfType<GameManager>().IsPaused();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level01()
    {
        SceneManager.LoadScene(4);
    }

    public void Level02()
    {
        SceneManager.LoadScene(5);
    }

    public void Level03()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadingLevel01()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }
    public void LoadingLevel02()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }
    public void LoadingLevel03()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(6);
    }
}
