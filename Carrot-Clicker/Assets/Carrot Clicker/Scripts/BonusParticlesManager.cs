using UnityEngine;

public class BonusParticlesManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject bonusParticlePrefab;
    private void Awake()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallback;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CarrotClickedCallback(Vector2 clickedPosition)
    {
        Instantiate(bonusParticlePrefab, clickedPosition, Quaternion.identity, transform);
    }

}
