using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private UpgradeButton upgradeButton;
    [SerializeField] private Transform upgradeButtonParent;

    [Header(" Data ")]
    [SerializeField] private UpgradeSO[] upgrades;

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

        int upgradeLevel = PlayerPrefs.GetInt("Upgrade" + index);

        Sprite icon = upgrade.icon;
        string title = upgrade.title;
        string subtitle = string.Format("lvl{0} (+{1} Cps)", upgradeLevel, upgrade.cpsPerLevel);
        string price = upgrade.GetPrice(upgradeLevel).ToString();

        upgradeButtonInstance.Configue(icon, title, subtitle, price);
    }
}
