using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public float hP = 100f;  // Initialize HP to a default value
    public float damage = 1f;  // Initialize damage to a default value
    public float attackSpeed = 1f;  // Initialize attackSpeed to a default value

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure the player manager persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseHealth(float value)
    {
        hP -= value;
        if (hP < 0)
        {
            hP = 0;  // Ensure HP doesn't go below 0
            Debug.Log("Death");
        }
    } // Recive Damage

    public void Heal(float value)
    {
        hP += value;
        if (hP > 100)
        {
            hP = 100f;  // Ensure HP doesn't exceed 100
        }
    } // Restore Health

    public void IncreaseAttackSpeed(float value)
    {
        attackSpeed -= value;
        if (attackSpeed < 0.1f)
        {
            attackSpeed = 0.1f;  // Ensure attack speed doesn't go below 0.1
        }
    } // Increase Attack Speed

    public void DecreaseAttackSpeed(float value)
    {
        attackSpeed += value;
        if (attackSpeed > 1f)
        {
            attackSpeed = 1f;  // Ensure attack speed doesn't exceed 1
        }
    } // Lower Attack Speed

    public void IncreaseDamage(float value)
    {
        damage += value;
        if (damage > 10f)
        {
            damage = 10f;  // Ensure damage doesn't exceed 10
        }
    } // Increase Damage

    public void LowerDamage(float value)
    {
        damage -= value;
        if (damage < 1f)
        {
            damage = 1f;  // Ensure damage doesn't go below 1
        }
    } // Decrease Damage
}
