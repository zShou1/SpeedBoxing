using UnityEngine;

public class LosePanel : UIPanel
{
    public void OnRetryButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        GameManager.Instance.CurrentLevel = 1;
        DataManager.Instance.TryDecreaseEnergyAndLoadScene(DataManager.Instance.GetCurrentSceneName());
    }
    
    public void OnHomeButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        UIManager.Instance.Hide(UIManager.Panel.LosePanel);
        DataManager.Instance.LoadScene("MainMenu");
    }
}
