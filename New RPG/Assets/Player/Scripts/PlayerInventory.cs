using System;
using System.Collections.Generic; 
using UnityEngine;
using Random = System.Random;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;

    public List<Item> inventory = new List<Item>();

    string[] itemNames = {"Potion", "Sword", "Armor"};
    
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int value = UnityEngine.Random.Range(1, 100);
            string itemName = itemNames[UnityEngine.Random.Range(0, itemNames.Length)];
            
            Item newItem = new Item(value, itemName);
            inventory.Add(newItem);
            print("Picked up: " + newItem.name + " valued at " + newItem.value + " gold.");
        }
            
    }
}
