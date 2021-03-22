using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Canvas MainMenu, Credits;
    public void GoToCredits()
    {
        MainMenu.gameObject.SetActive(false);
        Credits.gameObject.SetActive(true);
    }

    public void GoBackToMenu()
    {
        MainMenu.gameObject.SetActive(true);
        Credits.gameObject.SetActive(false);
    }

   public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
