using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScore : BaseUI
{
    TextMeshProUGUI bestScoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
    }

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public void SetUI(int bestScore)
    {
        bestScoreText.text = $"Best Score: {bestScore}";
    }
}
