using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LevelManager))]
public class RatingCalculation : MonoBehaviour
{
    LevelManager levelManager;
    
    [SerializeField] List<GameObject> stars;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] GameObject newHighScoreText;

    private void Awake() {
        levelManager = GetComponent<LevelManager>();
    }

    public void CalculateRating()
    {
        if (levelManager.CurrentScore <= levelManager.BestPossibleNumberOfAttemps)
        {
            for (int i = 0; i < 3; i++)
            {
                stars[i].SetActive(true);
            }
        }

        else if (levelManager.CurrentScore > levelManager.BestPossibleNumberOfAttemps && 
        levelManager.CurrentScore <= levelManager.BestPossibleNumberOfAttemps + levelManager.BestPossibleNumberOfAttemps/2)
        {
            for (int i = 0; i < 2; i++)
            {
                stars[i].SetActive(true);
            }
        }

        else if (levelManager.CurrentScore > levelManager.BestPossibleNumberOfAttemps + levelManager.BestPossibleNumberOfAttemps/2)
        {
            for (int i = 0; i < 1; i++)
            {
                stars[i].SetActive(true);
            }
        }
    }

    public void SetScores()
    {
        bestScoreText.text = levelManager.BestScore.ToString();
        currentScoreText.text = levelManager.CurrentScore.ToString();

        if (levelManager.CurrentScore < levelManager.BestScore) newHighScoreText.SetActive(true); 
    }
}
