using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;

    [SerializeField] int levelIndex;
    public int LevelIndex { get { return levelIndex; } }

    [SerializeField] int bestPossibleNumberOfAttemps;
    public int BestPossibleNumberOfAttemps { get { return bestPossibleNumberOfAttemps; } }

    [SerializeField] private int currentScore;
    public int CurrentScore { get { return currentScore; } }
    
    [SerializeField] private int bestScore = 0;
    public int BestScore 
    { 
        get 
        { 
            return bestScore; 
        }
        set
        {
            bestScore = value;
        }     
    }

   public static Action OnAction;

    private void OnEnable() {
        OnAction += () => { currentScore++; }; 
    }

    private void Start() 
    {
        LevelData levelData = SaveSystem.LoadScore();
        bestScore = levelData.BestScores[LevelIndex];
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveScore()
    {
        if (currentScore < bestScore) SaveSystem.SaveScore(this);
    }
}
