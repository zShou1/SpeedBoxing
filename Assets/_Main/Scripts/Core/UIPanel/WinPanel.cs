using UnityEngine;

public class WinPanel : UIPanel
{
    public void OnNextLevelButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        GameManager.Instance.CurrentLevel++;
        DataManager.Instance.LoadScene(DataManager.Instance.GetCurrentSceneName());
    }
    
    public void OnHomeButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        UIManager.Instance.Hide(UIManager.Panel.WinPanel);
        DataManager.Instance.LoadScene("MainMenu");
    }
}
