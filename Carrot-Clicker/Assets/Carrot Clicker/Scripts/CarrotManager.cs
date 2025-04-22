using UnityEngine;
using TMPro;

public class CarrotManager : MonoBehaviour
{
    public static CarrotManager instance;

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header(" Data ")]
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int frenzyModeMultiplier;
    private int carrotIncrement;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();
        carrotIncrement = 1;
        InputManager.onCarrotClicked += CarrotClickedCallback;
        Carrot.onFrenzyModeStarted += FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped += FrenzyModeStoppedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
        Carrot.onFrenzyModeStarted -= FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped -= FrenzyModeStoppedCallback;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCarrots(float value)
    {
        totalCarrotsCount += value;

        UpdateCarrotsText();

        SaveData();
    }

    private void CarrotClickedCallback()
    {
        totalCarrotsCount += carrotIncrement;

        UpdateCarrotsText();

        SaveData();
    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotsCount + " Carrots!";
    }

    private void FrenzyModeStartedCallback()
    {
        carrotIncrement = frenzyModeMultiplier;
    }

    private void FrenzyModeStoppedCallback()
    {
        carrotIncrement = 1;
    }
    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }
    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

        UpdateCarrotsText();
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrement;
    }
}
