using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour
{
    public void ToScene(string name)
    {
        SceneFade.ChangeScene(name);
        Time.timeScale = 1f;
    }

    public void ToScene(int buildIndex)
    {
        SceneFade.ChangeScene(buildIndex);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneFade.ChangeScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Leave() => Application.Quit();
}
