using System;
using UnityEngine;

public class PlayerEntity : Entity
{
    public float AttackRange; 
    
    public static string playerName;
    public static float attackRange;

    public static int damage; 

    private void Start()
    {
        playerName = Name;
        currentHealth = health;
        attackRange = AttackRange;
        damage = Damage; 
    }
}
