using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    [SerializeField] int PlayerScore;
    private void Awake()
    {
        SingletonActivation();
    }

    private void SingletonActivation()
    {
        if (FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int ReturnScore()
    {
        return PlayerScore;
    }
    public void UpdateScore(int newScore)
    {
        PlayerScore = newScore;
    }
    public void ResetGameScore()
    {
        PlayerScore = 0;
    }
}
