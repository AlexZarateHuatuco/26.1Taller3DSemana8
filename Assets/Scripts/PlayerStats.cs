using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float health = 100;
    [SerializeField] private float armor = 100;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float damage = 10;
    [SerializeField] private float jumpForce = 5;

    [SerializeField] private int level = 1;
    public Action OnStatsChanged;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public void AddHealth(float amount)
    {
        health += amount;
        OnStatsChanged?.Invoke();
    }

    public void AddArmor(float amount)
    {
        armor += amount;
        OnStatsChanged?.Invoke();
    }

    public void AddDamage(float amount)
    {
        damage += amount;
        OnStatsChanged?.Invoke();
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
        OnStatsChanged?.Invoke();
    }

    public void AddJump(float amount)
    {
        jumpForce += amount;
        OnStatsChanged?.Invoke();
    }
}