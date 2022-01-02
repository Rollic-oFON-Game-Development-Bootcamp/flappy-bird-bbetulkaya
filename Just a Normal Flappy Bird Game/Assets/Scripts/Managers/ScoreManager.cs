using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager instance;
    public static ScoreManager Instance => instance ?? (instance = FindObjectOfType<ScoreManager>());
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    [SerializeField] private int currentScore;
    [SerializeField] private static int highScore;

    public void SetCurrentScore(int score)
    {
        currentScore += score;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
    public void SetHighScore(int score)
    {
        highScore = score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void SaveScore()
    {
        if (currentScore > highScore)
        {
            SetHighScore(currentScore);
        }
    }
}
