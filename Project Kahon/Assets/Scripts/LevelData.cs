using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    //public int BestScore;
    //public int LevelIndex;
    public int[] BestScores = {0,0,0,0,0};

    public LevelData(LevelManager levelManager)
    {
        BestScores[levelManager.LevelIndex] = levelManager.CurrentScore;
    }
}
