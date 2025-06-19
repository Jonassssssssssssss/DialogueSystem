using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public bool TaskDone;

    public enum TaskType {GetItem, };
    public TaskType Type;

    public enum Items { none, glasses };
    public Items ItemToGet;

    InventoryPlayer IP;

    void Start()
    {
        IP = GameObject.Find("Player").GetComponent<InventoryPlayer>();
    }

    void Update()
    {
        switch (ItemToGet)
        {
            case Items.glasses:
                if (IP.CheckForItem(InventoryPlayer.Inventory.glasses) == true) TaskDone = true;
                break;
        }
    }
}
