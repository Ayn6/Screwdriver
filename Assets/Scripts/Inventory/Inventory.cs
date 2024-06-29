using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public bool IsEnoughtItem(List<Item> required)
    {
        // Создаем словарь для подсчета требуемых предметов
        Dictionary<string, int> requiredItems = new Dictionary<string, int>();
        foreach (var item in required)
        {
            if (requiredItems.ContainsKey(item.ingridient.name))
            {
                requiredItems[item.ingridient.name] += item.count;
            }
            else
            {
                requiredItems[item.ingridient.name] = item.count;
            }
        }

        // Проверяем наличие требуемых предметов в инвентаре
        foreach (var kvp in requiredItems)
        {
            int availableCount = inventory.Where(i => i.ingridient.name == kvp.Key).Sum(i => i.count);
            if (availableCount < kvp.Value)
            {
                return false; // Не хватает предметов
            }
        }

        return true; // Достаточно предметов
    }

    public bool RemoveItem(string name, int count)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].ingridient.name == name)
            {
                if (inventory[i].count < count)
                {
                    return false;
                }
                if (inventory[i].count == count)
                {
                    inventory.RemoveAt(i);
                    return true;
                }
                else
                {
                    inventory[i].count -= count;
                    return true;
                }
            }
        }
        return false;
    }

}
