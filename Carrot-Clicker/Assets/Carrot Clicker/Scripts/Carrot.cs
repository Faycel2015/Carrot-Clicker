using UnityEngine;
using UnityEngine.UI;
using System;

public class Carrot : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform carrotRendererTransform;
    [SerializeField] private Image fillImage;

    [Header(" Settings ")]
    [SerializeField] private float fillRate;
    private bool isFrenzyModeActive;

    [Header(" Actions ")]
    public static Action onFrenzyModeStarted;
    public static Action onFrenzyModeStopped;
    private void Awake()
    {
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
        // Anime the Carrot Renderer
        Animate();

        // Fill the carrot image
        if (!isFrenzyModeActive)
            Fill();
    }

    private void Animate()
    {
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * .7f, 15f).setLoopPingPong(1);
    }

    private void Fill()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount += fillRate;

            if (fillImage.fillAmount >= 1)
                StartFrenzyMode();
        }
    }

    private void StartFrenzyMode()
    {
        isFrenzyModeActive = true;

        LeanTween.value(1, 0, 5).setOnUpdate((value) => fillImage.fillAmount = value)
        .setOnComplete(StopFrenzyMode);

        onFrenzyModeStarted?.Invoke();

    }

    private void StopFrenzyMode()
    {
        isFrenzyModeActive = false;

        onFrenzyModeStopped?.Invoke();
    }
}
