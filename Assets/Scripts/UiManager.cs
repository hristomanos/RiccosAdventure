using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;

    int totalAvailbleScore;

    private void Start()
    {
        ScoreManager.Instance.OnScoreChange += UpdateScore;
    }

    public void InitializeScore(int totalAvailableScore)
    {
        this.totalAvailbleScore = totalAvailableScore;
        currentScoreText.text = $"0 / {totalAvailableScore}";
    }

    private void UpdateScore(int newScore)
    {
        int currentScore = ScoreManager.Instance.GetCurrentScore();
        currentScoreText.text = $"{currentScore} / {totalAvailbleScore}";
    }
}
