using UnityEngine;

public class MainMenuUIManager : Singleton<MainMenuUIManager>
{
    public enum MainMenuPanel
    {
        MainPanel,
        KeymapPanel,
        OutOfEnergyPanel,
        ShopPanel
    }
    
    [Header("Panels")]
    [SerializeField] private MainPanel mainPanel;
    [SerializeField] private KeymapPanel keymapPanel;
    [SerializeField] private OutOfEnergyPanel outOfEnergyPanel;
    [SerializeField] private ShopPanel shopPanel;
    
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        RegisterEvent();
    }
    
    private void RegisterEvent()
    {
        DataManager.Instance.OnOutOfEnergy += OnOutOfEnergy;
    }
    
    private void OnOutOfEnergy()
    {
        Show(MainMenuPanel.OutOfEnergyPanel);
    }
    
    public void Show(MainMenuPanel panel)
    {
        switch (panel)
        {
            case MainMenuPanel.MainPanel:
                mainPanel.Open(Constants.DurationOpenPanel);
                break;
            case MainMenuPanel.KeymapPanel:
                keymapPanel.Open(Constants.DurationOpenPanel);
                break;
            case MainMenuPanel.OutOfEnergyPanel:
                outOfEnergyPanel.Open(Constants.DurationOpenPanel);
                break;
            case MainMenuPanel.ShopPanel:
                shopPanel.Open(Constants.DurationOpenPanel);
                break;
        }
    }
    
    public void Hide(MainMenuPanel panel)
    {
        switch (panel)
        {
            case MainMenuPanel.MainPanel:
                mainPanel.Close(Constants.DurationClosePanel);
                break;
            case MainMenuPanel.KeymapPanel:
                keymapPanel.Close(Constants.DurationClosePanel);
                break;
            case MainMenuPanel.OutOfEnergyPanel:
                outOfEnergyPanel.Close(Constants.DurationClosePanel);
                break;
            case MainMenuPanel.ShopPanel:
                shopPanel.Close(Constants.DurationClosePanel);
                break;
        }
    }
    
    
}
