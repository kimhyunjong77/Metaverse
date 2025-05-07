using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Home,
    Game,
    Score,
    BestScore,
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance => instance;

    UIState currentState = UIState.Home;

    HomeUI homeUI;
    GameUI gameUI;
    ScoreUI scoreUI;
    BestScore bestScore;

    private void Awake()
    {
        instance = this;

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this);

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this);

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);

        bestScore = GetComponentInChildren<BestScore>(true);
        bestScore?.Init(this);

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
        bestScore?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        GameManager.Instance.StartGame();
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickReStart()
    {
        GameManager.Instance.RestartGame();
    }

    public void UpdateScoreUI(int score)
    {
        gameUI?.SetUI(score);
    }

    public void ShowScoreUI(int score, int bestScore)
    {
        scoreUI?.SetUI(score, bestScore);
        this.bestScore?.SetUI(bestScore);
    }
}
