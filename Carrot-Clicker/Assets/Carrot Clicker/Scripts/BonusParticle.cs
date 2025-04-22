using UnityEngine;
using TMPro;
public class BonusParticle : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshPro bonusText;

    public void Configure(int carrotMultiplier)
    {
        bonusText.text = "+" + carrotMultiplier;
    }
}
