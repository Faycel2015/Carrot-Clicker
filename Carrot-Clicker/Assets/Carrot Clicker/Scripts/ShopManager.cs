using System;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [Header(" Elements ")]
    [SerializeField] private UpgradeButton upgradeButton;
    [SerializeField] private Transform upgradeButtonParent;

    [Header(" Data ")]
    [SerializeField] private UpgradeSO[] upgrades;

    [Header(" Actions ")]
    public static Action<int> onUpgradePurchased;

    private void Awake()
    {
        if(instance == null)
        instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnButtons()
    {
        for (int i = 0; i < upgrades.Length; i++)
            SpawnButton(i);
    }

    private void SpawnButton(int index)
    {
        UpgradeButton upgradeButtonInstance = Instantiate(upgradeButton, upgradeButtonParent);

        UpgradeSO upgrade = upgrades[index];

        int upgradeLevel = GetUpgradeLevel(index);

        Sprite icon = upgrade.icon;
        string title = upgrade.title;
        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString("F0");

        upgradeButtonInstance.Configue(icon, title, subtitle, price);

        upgradeButtonInstance.GetButton().onClick.AddListener(() => UpgradeButtonClickedCallback(index));
    }

    private void UpgradeButtonClickedCallback(int upgradeIndex)
    {
        if (CarrotManager.instance.TryPurchase(GetUpgradePrice(upgradeIndex)))
            IncreaseUpgradeLevel(upgradeIndex);
        else
            Debug.Log("You're too poor for the upgrade ! ");
    }

    private void IncreaseUpgradeLevel(int upgradeIndex)
    {
        int currentUpgradeLevel = GetUpgradeLevel(upgradeIndex);
        currentUpgradeLevel++;

        // Save the upgrade level
        SaveUpgradeLevel(upgradeIndex, currentUpgradeLevel);

        UpdateVisuals(upgradeIndex);

        onUpgradePurchased?.Invoke(upgradeIndex);
    }

    private void UpdateVisuals(int upgradeIndex)
    {
        UpgradeButton upgradeButton = upgradeButtonParent.GetChild(upgradeIndex).GetComponent<UpgradeButton>();

        UpgradeSO upgrade = upgrades[upgradeIndex];

        int upgradeLevel = GetUpgradeLevel(upgradeIndex);

        Sprite icon = upgrade.icon;
        string title = upgrade.title;
        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString("F0");

        upgradeButton.UpdateVisuals(subtitle, price);
    }

    private double GetUpgradePrice(int upgradeIndex)
    {
        return upgrades[upgradeIndex].GetPrice(GetUpgradeLevel(upgradeIndex));
    }

    public int GetUpgradeLevel(int upgradeIndex)
    {
        return PlayerPrefs.GetInt("Upgrade" + upgradeIndex);
    }

    private void SaveUpgradeLevel(int upgradeIndex, int upgradeLevel)
    {
        PlayerPrefs.SetInt("Upgrade" + upgradeIndex, upgradeLevel);
    }

    public UpgradeSO[] GetUpgrades()
    {
        return upgrades;
    }
}
