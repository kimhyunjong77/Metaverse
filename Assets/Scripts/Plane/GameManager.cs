using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance => gameManager;

    private UIManager uiManager;
    private int currentScore = 0;
    private int bestScore = 0;

    private bool isGameStarted = false;
    public bool IsGameStarted => isGameStarted;

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Start()
    {
        uiManager.ChangeState(UIState.Home);
    }

    public void StartGame()
    {
        currentScore = 0;
        isGameStarted = true;

        uiManager.ChangeState(UIState.Game);
        uiManager.UpdateScoreUI(currentScore);

        Player player = FindObjectOfType<Player>();
        player?.EnableGravity();
    }

    public void AddScore(int score)
    {
        currentScore += score;

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        uiManager.UpdateScoreUI(currentScore);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        isGameStarted = false;
        uiManager.ChangeState(UIState.Score);
        uiManager.ShowScoreUI(currentScore, bestScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}