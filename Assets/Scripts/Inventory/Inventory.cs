using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public bool UseItem(Item itemName)
    {
        foreach (Item item in inventory)
        {
            if (item == itemName)
            {
                if (item.count > 0)
                {
                    item.count--;
                    return true;
                }
                else
                {
                    Debug.Log("No more items left: " + itemName);
                    return false;
                }
            }
        }
        Debug.Log("Item not found: " + itemName);
        return false;
    }
}
