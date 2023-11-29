using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [Header("You need to add scenes to your project first.")]
    [Header("Carrot")]
    [SerializeField] private int carrotWinScene;
    [Header("Bird")]
    [SerializeField] private int birdWinScene;
    [SerializeField] private int gameOverScene;

    public void CarrotWinEnd()
    {
        if (carrotWinScene != 0)
        {
            SceneManager.LoadScene(carrotWinScene);
        }
    }

    public void BirdWinEnd()
    {
        if (birdWinScene != 0)
        {
            SceneManager.LoadScene(birdWinScene);
        }
    }

    public void GameOver()
    {
        if (gameOverScene != 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            GameOver();
        }
    }
}
