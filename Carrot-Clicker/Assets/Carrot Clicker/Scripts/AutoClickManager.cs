using UnityEngine;

public class AutoClickManager : MonoBehaviour
{
    [Header(" Data ")]
    [SerializeField] private int level;
    [SerializeField] private float carrotsPerSecond;

    private void Awake()
    {
        LoadData();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carrotsPerSecond = level * .1f;

        InvokeRepeating("AddCarrots", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddCarrots()
    {
        CarrotManager.instance.AddCarrots(carrotsPerSecond);
        Debug.Log("Adding" + carrotsPerSecond + " carrots");
    }

    public void Upgrade()
    {
        level++;
        carrotsPerSecond = level * .1f;

        SaveData();
    }
    private void LoadData()
    {
        level = PlayerPrefs.GetInt("AutoClickLevel");
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("AutoClickLevel", level);
    }
}
