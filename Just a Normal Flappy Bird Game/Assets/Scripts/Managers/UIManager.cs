using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Game Panels
    [SerializeField] private RectTransform gameOverPanel;
    [SerializeField] private RectTransform gamePlayPanel;

    // Text Inputs
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text finalScoreText;


    public void GameOverPanel(bool isActive)
    {
        if (gamePlayPanel.gameObject.activeSelf) GamePlayPanel(false);
        gameOverPanel.gameObject.SetActive(isActive);

        var highScore = ScoreManager.Instance.GetHighScore();
        var finalScore = ScoreManager.Instance.GetCurrentScore();
        highScoreText.text = highScore.ToString();
        finalScoreText.text = finalScore.ToString();
    }
    public void GamePlayPanel(bool isActive)
    {
        if (gameOverPanel.gameObject.activeSelf) GameOverPanel(false);
        gamePlayPanel.gameObject.SetActive(isActive);
    }
    public void UpdateScoreText(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}
