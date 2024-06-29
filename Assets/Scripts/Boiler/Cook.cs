using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Cook : MonoBehaviour
{

    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventorySlots inventorySlots;

    public List<Ingridient> item = new List<Ingridient>();
    private bool click = false;
    private int index = -1;

    public void GetIndex(GameObject obj)
    {
        if (click)
        {
            if (index != obj.transform.GetSiblingIndex())
            {
                click = true;
                index = obj.transform.GetSiblingIndex();
            }
            else
            {
                index = -1;
                click = false;
            }

        }
        else
        {
            click = true;
            index = obj.transform.GetSiblingIndex();
        }
    }

    public void Put()
    {
        if (playerInventory.inventory[index].count <= 0 || index == -1)
        {
            return;
        }
        else
        {
            // Проверяем, есть ли уже такой элемент в коллекции item
            bool found = false;
            foreach (var existingItem in item)
            {
                if (existingItem.Equals(playerInventory.inventory[index].ingridient))
                {
                    // Если элемент уже есть, увеличиваем его количество на 1
                    existingItem.count++;
                    found = true;
                    break;
                }
            }

            // Если элемент не найден, добавляем его в коллекцию item
            if (!found)
            {
                item.Add(playerInventory.inventory[index].ingridient);
            }

            // Уменьшаем количество в инвентаре игрока и вызываем Restart()
            playerInventory.inventory[index].count--;
            inventorySlots.Restart();
        }
    }
}
