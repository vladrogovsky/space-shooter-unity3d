using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    [SerializeField] GameSession GameSessionObj;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Text>().text = GameSessionObj.ReturnScore().ToString();
    }
	public void UpdateScore(int newScore)
    {
        if (newScore >= 0)
        {
            var finalScore = GameSessionObj.ReturnScore() + newScore;
            GameSessionObj.UpdateScore(finalScore);
            gameObject.GetComponent<Text>().text = finalScore.ToString();
        }
    }
}
