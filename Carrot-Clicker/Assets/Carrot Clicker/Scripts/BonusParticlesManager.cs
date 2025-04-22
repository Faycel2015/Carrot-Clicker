using UnityEngine;
using UnityEngine.Pool;

public class BonusParticlesManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private CarrotManager carrotManager;
    [SerializeField] private GameObject bonusParticlePrefab;

    [Header(" Pooling ")]
    private ObjectPool<GameObject> bonusParticlesPool;
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
        bonusParticlesPool = new ObjectPool<GameObject>(CreateFunction, ActionOnGet, ActionRelase, ActionOnDestroy);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private GameObject CreateFunction()
    {
        return Instantiate(bonusParticlePrefab, transform);
    }

    private void ActionOnGet(GameObject bonusParticle)
    {
        bonusParticle.SetActive(true);
    }

    private void ActionRelase(GameObject bonusParticle)
    {
        bonusParticle.SetActive(false);
    }

    private void ActionOnDestroy(GameObject bonusParticle)
    {
        Destroy(bonusParticle);
    }

    private void CarrotClickedCallback(Vector2 clickedPosition)
    {
        GameObject bonusParticleIstance = bonusParticlesPool.Get();

        bonusParticleIstance.transform.position = clickedPosition;
        bonusParticleIstance.GetComponent<BonusParticle>().Configure(carrotManager.GetCurrentMultiplier());

        LeanTween.delayedCall(1, () => bonusParticlesPool.Release(bonusParticleIstance));
    }

}
