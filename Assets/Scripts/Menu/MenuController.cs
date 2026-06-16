using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
        string goToLevel = "Level" + level.ToString();
        SceneManager.LoadScene(goToLevel);
    }
}
