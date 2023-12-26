using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private readonly string Level = "Level";

    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
    }
}
