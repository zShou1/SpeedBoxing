using System;
using TMPro;
using UnityEngine;

public class ShowTimeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;

    /*private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }*/

    private void Start()
    {
        RegisterEvents();
    }

    private void RegisterEvents()
    {
        GameManager.Instance.OnTimeChanged += UpdateTimeUI;
    }
    
    private void UpdateTimeUI(int time)
    {
        if (timeText)
        {
            timeText.SetText(IntToTime(time));
        }
    }
    
    private string IntToTime(int second)
    {
        int minutes = second / 60;
        int seconds = second % 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
