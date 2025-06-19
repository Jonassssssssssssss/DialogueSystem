using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    public enum Inventory { none, glasses };
    public List <Inventory> inventory;

    public void GetItem(Inventory item)
    {
        inventory.Add(item);
    }

    public bool CheckForItem(Inventory _inventory)
    {
        bool ItemExists = false;

        foreach (Inventory item in inventory)
        {
            if (item == _inventory) ItemExists = true;
        }

        return ItemExists;
    }
}
