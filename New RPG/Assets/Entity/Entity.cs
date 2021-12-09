using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public string Name; 
    
    [Header("Base stats")]
    public int health;
    public int mana;
    public int stamina;
    public int Damage; 

    [Header("Race Info")]
    public Race race;

    [HideInInspector] public int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }
}
