using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Core.IAP
{
    public class BuyButton : MonoBehaviour
    {
        public string SkuName;
        public Button buyButton;

        private void Reset()
        {
            buyButton = GetComponent<Button>();
        }

        private void Awake()
        {
            buyButton.onClick.AddListener(Buy);
        }

        private void Buy()
        {
            Debug.Log(SkuName);
            OculusIAP.Instance.Buy(SkuName);
        }
    }
}
