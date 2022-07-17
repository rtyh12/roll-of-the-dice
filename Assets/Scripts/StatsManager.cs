using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatsManager
{
    private
    static List<int> loveScores = new List<int> { 0,0,0,0,0,0 }; 

    public static void resetLoveScores()
    {
        loveScores = new List<int> { 0, 0, 0, 0, 0, 0 };
    }

    public static void setLoveScore(int currentScene, int newLoveScore)
    {
        loveScores[currentScene] = newLoveScore;
    }

    public static int getLoveScore(int currentScene)
    {
        return loveScores[currentScene];
    }

}
