using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pausePanel;

    public AudioClip popFx;

    public void Pause()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        this.GetComponent<AudioSource>().PlayOneShot(popFx);
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        this.GetComponent<AudioSource>().PlayOneShot(popFx);
    }

    public void toMain()
    {
        SceneManager.LoadScene(0);
    }

    public void restartScene()
    {
        Unpause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
