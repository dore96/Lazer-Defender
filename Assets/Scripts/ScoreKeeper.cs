using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int playerScore = 0;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void UpdateScore(int value)
    {
        playerScore += value;
        Mathf.Clamp(playerScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
