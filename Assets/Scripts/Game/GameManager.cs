using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 300f;
    public string winSceneName = "WinScene";
    public string loseSceneName = "LoseScene";

    private bool gameIsOver = false;
    private void Start()
    {
        PlayerManager.Instance.ResetPlayer();
    }
    void Update()
    {
        if (gameIsOver)
            return;

        gameDuration -= Time.deltaTime;

        if (gameDuration <= 0)
        {
            WinGame();
        }

        if (PlayerManager.Instance.hP <= 0)
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        gameIsOver = true;
        SceneManager.LoadScene(winSceneName);
    }

    void LoseGame()
    {
        gameIsOver = true;
        Invoke("LoadLoseScene", 5f);
    }

    void LoadLoseScene()
    {
        SceneManager.LoadScene(loseSceneName);
    }
}