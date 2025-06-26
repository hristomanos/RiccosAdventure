using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

   public Action<int> OnScoreChange;
    
    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        score++;
        OnScoreChange.Invoke(score);
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
