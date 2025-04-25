using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("AddCarrots", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddCarrots()
    {
        UpgradeSO[] upgrades = ShopManager.instance.GetUpgrades();

        if (upgrades.Length <= 1)
            return;
        
        double totalCarrots = 0;

        for (int i = 1; i < upgrades.Length; i++)
        {
            // Grab the amount of carrots for the upgrade
            double upgradeCarrots = upgrades[i].cpsPerLevel * ShopManager.instance.GetUpgradeLevel(i);
            totalCarrots += upgradeCarrots;
        }

        // At this point we have the amount of carrots we need to add every second
        CarrotManager.instance.AddCarrots(totalCarrots);
    }
}
