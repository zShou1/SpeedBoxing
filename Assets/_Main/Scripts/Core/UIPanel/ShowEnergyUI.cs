using System;
using TMPro;
using UnityEngine;

public class ShowEnergyUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI energyText;

    private void Start()
    {
        DataManager.Instance.OnEnergyChanged += OnEnergyChanged;
        energyText.text = DataManager.Instance.Energy.ToString();
    }
    
    private void OnEnergyChanged(int energy)
    {
        energyText.text = energy.ToString();
    }
}
