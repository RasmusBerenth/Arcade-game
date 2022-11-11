using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject backButton;
    public GameObject backButton2;
    public GameObject playButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Controlls()
    {
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void Credits()
    {
        EventSystem.current.SetSelectedGameObject(backButton2);
    }

    public void Back()
    {
        EventSystem.current.SetSelectedGameObject(playButton);
    }
}
