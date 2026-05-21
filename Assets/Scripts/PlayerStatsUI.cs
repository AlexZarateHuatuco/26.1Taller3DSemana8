using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    [Header("Textos")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text jumpText;
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        player.OnStatsChanged += UpdateUI;

        UpdateUI();
    }

    private void OnDestroy()
    {
        player.OnStatsChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        healthText.text = "Vida: " + player.Health;
        armorText.text = "Armadura: " + player.Armor;
        damageText.text = "Daño: " + player.Damage;
        speedText.text = "Velocidad: " + player.MoveSpeed;
        jumpText.text = "Salto: " + player.JumpForce;
        levelText.text = "Nivel: " + player.Level;
    }
}