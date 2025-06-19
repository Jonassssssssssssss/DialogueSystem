using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {none, glasses };
    public ItemType type;

    [SerializeField] GameObject _pickUpEffect;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<InventoryPlayer>() && type != ItemType.none)
        {
            GetPickedUp(collider);
        }
    }

    void GetPickedUp(Collider2D collider)
    {
        if (_pickUpEffect != null) Instantiate(_pickUpEffect, transform.position, Quaternion.identity);

        switch (type)
        {
            case ItemType.glasses:
                collider.GetComponent<InventoryPlayer>().GetItem(InventoryPlayer.Inventory.glasses);
                break;
        }

        Destroy(gameObject);
    }
}
