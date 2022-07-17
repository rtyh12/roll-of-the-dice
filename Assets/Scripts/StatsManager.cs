using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StatsManager
{
    // The n-th entry of this list corresponds with the n+2-th scene,
    // as scene 2 is the first dating scene
    public static List<int> loveScores = new List<int> { 0, 0, 0, 0, 0, 0 };

    public static void resetLoveScores()
    {
        loveScores = new List<int> { 0, 0, 0, 0, 0, 0 };
    }

    public static void setLoveScore(int newLoveScore)
    {
        loveScores[SceneManager.GetActiveScene().buildIndex - 3] = newLoveScore;
    }

    public static int getLoveScore()
    {
        return loveScores[SceneManager.GetActiveScene().buildIndex - 3];
    }

    public static int getWinnerID()
    {
        int id = 0;
        for (int i = 1; i < loveScores.Count; i++)
        {
            if (loveScores[i] > id) { id = i; }
        }
        return id;
    }
}
