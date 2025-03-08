using Oculus.Platform;
using Oculus.Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sku
{
    public string sku;
    public string price;
    public Sku(string sku, string price)
    {
        this.sku = sku;
        this.price = price;
    }
    public void Buy()
    {
        // Cập nhật logic mua hàng theo SKU
        switch (sku)
        {
            case "energy1":
                DataManager.Instance.Energy += 1;
                break;
            case "energy5":
                DataManager.Instance.Energy += 5;
                break;
            case "energy10":
                DataManager.Instance.Energy += 10;
                break;
            case "energy20":
                DataManager.Instance.Energy += 20;
                break;
            case "energy50":
                DataManager.Instance.Energy += 50;
                break;
            default:
                break;
        }
    }
}

public class OculusIAP : Singleton<OculusIAP>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    // Danh sách SKU (đảm bảo sku trùng với cài đặt trong Oculus Developer Dashboard)
    List<Sku> skusList;
    string[] skus; // Mảng chứa SKU, không phải giá

    // Dictionary để theo dõi purchase đang được consume
    private Dictionary<UInt64, string> skuDictionary = new Dictionary<UInt64, string>();

    void Start()
    {
        // Tạo danh sách SKU
        skusList = new List<Sku>
        {
            new Sku("energy1", "0.99"),
            new Sku("energy5", "4.99"),
            new Sku("energy10", "9.99"),
            new Sku("energy20", "19.99"),
            new Sku("energy50", "49.99")
        };

        // CHỈ LẤY SKU, KHÔNG LẤY giá
        skus = new string[skusList.Count];
        for (int i = 0; i < skusList.Count; i++)
        {
            skus[i] = skusList[i].sku;
        }

        // Khởi tạo Oculus Platform
        Core.AsyncInitialize().OnComplete(InitCallback);
    }

    private void InitCallback(Message<PlatformInitialize> msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("Error initializing Oculus Platform: " + msg.GetError().Message);
        }
        else
        {
            // Debug.Log("Oculus Platform initialized successfully.");
            Entitlements.IsUserEntitledToApplication().OnComplete(EntitlementCheckCallback);
        }
    }

    private void EntitlementCheckCallback(Message msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("User not entitled to application, cannot proceed.");
            // Application.Quit();
        }
        else
        {
            // Debug.Log("User is entitled.");
            GetPrices();
            GetPurchases();
        }
    }

    private void GetPrices()
    {
        IAP.GetProductsBySKU(skus).OnComplete(GetPricesCallback);
    }

    private void GetPricesCallback(Message<ProductList> msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("Error getting products by SKU: " + msg.GetError().Message);
            return;
        }
        foreach (var prod in msg.GetProductList())
        {
            // Debug.Log($"Product: {prod.Sku} - {prod.FormattedPrice}");
            // Bạn có thể cập nhật UI hiển thị giá ở đây nếu muốn
        }
    }

    private void GetPurchases()
    {
        IAP.GetViewerPurchases().OnComplete(GetPurchasesCallback);
    }

    private void GetPurchasesCallback(Message<PurchaseList> msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("Error getting purchases: " + msg.GetError().Message);
            return;
        }
        foreach (var purch in msg.GetPurchaseList())
        {
            // Debug.Log($"Purchase retrieved: {purch.Sku} - {purch.GrantTime}");
            // Consume purchase để hoàn tất giao dịch
            ConsumePurchase(purch.Sku);
        }
        CoinPurchaseDeductionCheck();
    }

    private void ConsumePurchase(string skuName)
    {
        var request = IAP.ConsumePurchase(skuName);
        skuDictionary[request.RequestID] = skuName;
        request.OnComplete(ConsumePurchaseCallback);
    }

    private void ConsumePurchaseCallback(Message msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("Error consuming purchase: " + msg.GetError().Message);
        }
        else
        {
            if (skuDictionary.TryGetValue(msg.RequestID, out var sku))
            {
                // Debug.Log($"Purchase consumed successfully for SKU: {sku}");
                AllocateCoins(sku); // Cấp coin/energy cho người chơi
                skuDictionary.Remove(msg.RequestID);
            }
            else
            {
                // Debug.Log("Purchase consumed successfully, but SKU not found in dictionary.");
            }
        }
    }

    public bool AllocateCoins(string skuName)
    {
        var sku = skusList.FirstOrDefault(s => s.sku == skuName);
        if (sku != null)
        {
            sku.Buy();
            // Debug.Log($"Allocated coins for SKU: {skuName}");
            return true;
        }
        // Debug.LogError("SKU not found in AllocateCoins: " + skuName);
        return false;
    }

    public void Buy(string skuName)
    {
#if UNITY_EDITOR
        // Trong editor, gọi AllocateCoins trực tiếp để test
        AllocateCoins(skuName);
#else
        // Debug.Log("Launching checkout flow for SKU: " + skuName);
        IAP.LaunchCheckoutFlow(skuName).OnComplete(BuyCallBack);
#endif
    }

    private void BuyCallBack(Message<Purchase> msg)
    {
        if (msg.IsError)
        {
            // Debug.LogError("Error in BuyCallBack: " + msg.GetError().Message);
            return;
        }
        // Debug.Log("Purchase completed: " + msg.Data.Sku);
        // Sau khi mua thành công, refresh danh sách purchase để consume giao dịch
        GetPurchases();
    }

    public void CoinPurchaseDeductionCheck()
    {
        string data = PlayerPrefs.GetString("PurchasedItem", "0");
        if (!string.IsNullOrEmpty(data))
        {
            string[] items = data.Split(new string[] { "@@" }, StringSplitOptions.None);
            foreach (string item in items)
            {
                if (int.TryParse(item, out int value))
                {
                    // Debug.Log("Retrieved value: " + value);
                    // Xử lý trừ coin nếu cần
                }
                else
                {
                    // Debug.LogError("Failed to parse item to integer: " + item);
                }
            }
        }
        else
        {
            // Debug.Log("No data found in PlayerPrefs for 'PurchasedItem'.");
        }
    }
}
