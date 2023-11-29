using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToAnotherPage : MonoBehaviour
{
    [Header("You need to add scene to your project first.")]
    [SerializeField] private int nextScene;
    public void GoToAnotherPage()
    {
        if(Time.timeScale == 0) //game is pause
        {
            Time.timeScale = 1;
        }
        if (nextScene != 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

}
