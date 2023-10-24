using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
        GameInfo.Score = 0;
    }

    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static void GameWin()
    {
        SceneManager.LoadScene("GameWin");
    }

    public static void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
