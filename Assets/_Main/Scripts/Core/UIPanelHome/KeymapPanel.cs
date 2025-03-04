using UnityEngine;

public class KeymapPanel : UIPanel
{
    public void OnCloseButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        MainMenuUIManager.Instance.Hide(MainMenuUIManager.MainMenuPanel.KeymapPanel);
        MainMenuUIManager.Instance.Show(MainMenuUIManager.MainMenuPanel.MainPanel);
    }
}
