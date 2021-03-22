using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public Canvas GameCanvas, EndGameCanvas;
    public void CheckEndGame(bool boolean)
    {
        if (boolean)
            EndGame();
    }
    public void EndGame()
    {
        GameCanvas.gameObject.SetActive(false);
        EndGameCanvas.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
