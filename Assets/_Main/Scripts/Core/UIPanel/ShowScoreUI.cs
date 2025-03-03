using System;
using TMPro;
using UnityEngine;

public class ShowScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += ShowScore;
    }

    private void ShowScore(int score)
    {
        if (scoreText)
        {
            scoreText.SetText(score.ToString());
        }
    }
}
