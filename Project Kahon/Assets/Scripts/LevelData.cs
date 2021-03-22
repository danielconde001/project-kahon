using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int BestScore;
    public int LevelIndex;
    public int[] LevelScores = new int[5];

    public LevelData(LevelManager levelManager)
    {
        BestScore = levelManager.CurrentScore;
    }
}
