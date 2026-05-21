using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsGenerator : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    [Header("Incrementos automáticos")]
    [SerializeField] private float healthIncrease = 10f;
    [SerializeField] private float armorIncrease = 10f;
    [SerializeField] private float speedIncrease = 0.5f;
    [SerializeField] private float damageIncrease = 2f;
    [SerializeField] private float jumpIncrease = 0.5f;

    private int currentIndex;

    private void Generate()
    {
        player.AddHealth(healthIncrease);
        player.AddArmor(armorIncrease);
        player.AddDamage(damageIncrease);
        player.AddSpeed(speedIncrease);
        player.AddJump(jumpIncrease);

        currentIndex++;
    }

    private void Update()
    {
        if (player.Level > currentIndex || Input.GetKeyDown(KeyCode.R))
        {
            Generate();
        }
    }
}