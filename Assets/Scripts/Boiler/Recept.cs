using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recept : MonoBehaviour
{
    [SerializeField] private Potion potion;
    [SerializeField] private InventorySlots inventorySlots;
    [SerializeField] private Image sprite;
    [SerializeField] private Inventory playerInventory;
    private Item item;

    public void Cooking()
    {
        if (inventorySlots.item[0] == potion.first && inventorySlots.item[1] == potion.second && inventorySlots.item[2] == potion.third)
        {
            Debug.Log(1);
            inventorySlots.item.Clear();

            item = new Item
            {
                ingridient = potion.ready,
                count = 1
            };

            playerInventory.inventory.Add(item);
            potion.sprite = sprite.sprite;
        }
        else
        {
            inventorySlots.item.Clear();
        }
    }
}
