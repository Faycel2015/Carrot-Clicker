using UnityEngine;
using TMPro;

public class CarrotManager : MonoBehaviour
{
    [Header(" Data ")]
    [SerializeField] private TextMeshProUGUI carrotsText;
    [SerializeField] private double totalCarrotsCount;
    [SerializeField] private int carrotIncrement;

    private void Awake()
    {
        LoadData();
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotsCount.ToString());
    }
    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotsCount);

        UpdateCarrotsText();
    }
}
