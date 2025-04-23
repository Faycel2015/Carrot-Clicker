using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform shopPanel;

    [Header(" Settings ")]
    private Vector2 openPosition;
    private Vector2 closedPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openPosition = Vector2.zero;
        closedPosition = new Vector2(shopPanel.rect.width, 0);

        shopPanel.anchoredPosition = openPosition;
    }

    public void Open()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, openPosition, .3f).setEase(LeanTweenType.easeInOutSine);

    }

    public void Close()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, closedPosition, .3f).setEase(LeanTweenType.easeInOutSine);
    }
}
