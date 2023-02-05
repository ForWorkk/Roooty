using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;


    public GameObject gameOverScreen;
    public GameObject gameWonScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void GameLost()
    {
        gameOverScreen.SetActive(true);
    }


    public void GameWon()
    {
        gameWonScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Loader.Load(Loader.Scene.LoopScene);

    }

    public void RestartRestartGame()
    {
        Loader.Load(Loader.Scene.DanceScene);

    }
}
