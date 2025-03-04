using UnityEngine;

public class ShopPanel : UIPanel
{
    public void OnCloseButtonClicked()
    {
        SoundManager.Instance.PlaySound2D(Sound.Click);
        UIManager.Instance.Hide(UIManager.Panel.ShopPanel);
        UIManager.Instance.Show(UIManager.Panel.LosePanel);
    }
}
