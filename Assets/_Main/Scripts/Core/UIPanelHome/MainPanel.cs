using UnityEngine;

public class MainPanel : UIPanel
{
    public void OnPlayButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        MainMenuUIManager.Instance.Hide(MainMenuUIManager.MainMenuPanel.MainPanel);
        DataManager.Instance.TryDecreaseEnergyAndLoadScene("Play");
    }
    public void OnKeymapButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        MainMenuUIManager.Instance.Hide(MainMenuUIManager.MainMenuPanel.MainPanel);
        MainMenuUIManager.Instance.Show(MainMenuUIManager.MainMenuPanel.KeymapPanel);
    }
    
    public void OnShopButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        MainMenuUIManager.Instance.Hide(MainMenuUIManager.MainMenuPanel.MainPanel);
        MainMenuUIManager.Instance.Show(MainMenuUIManager.MainMenuPanel.ShopPanel);
    }
    
    public void OnExitButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        Application.Quit();
    }
}
