using DG.Tweening;
using UnityEngine;

public class PausePanel : UIPanel
{
    public void OnResumeButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        UIManager.Instance.Hide(UIManager.Panel.PausePanel);
        Time.timeScale = 1;
        BGSoundManager.Instance.PlayBackgroundSound();
    }

    public void OnHomeButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        UIManager.Instance.Hide(UIManager.Panel.PausePanel);
        DataManager.Instance.LoadScene("MainMenu");
    }
    
}
