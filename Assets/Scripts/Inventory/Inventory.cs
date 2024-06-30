using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    public bool IsEnoughtItem(List<Item> required)
    {
        // ������� ������� ��� �������� ��������� ���������
        Dictionary<string, int> requiredItems = new Dictionary<string, int>();
        foreach (var item in required)
        {
            if (item?.ingridient?.name == null)
            {
                continue; // ���������� �������� � ��������������������� ������
            }

            if (requiredItems.ContainsKey(item.ingridient.name))
            {
                requiredItems[item.ingridient.name] += item.count;
            }
            else
            {
                requiredItems[item.ingridient.name] = item.count;
            }
        }

        // ��������� ������� ��������� ��������� � ���������
        foreach (var kvp in requiredItems)
        {
            int availableCount = inventory
                .Where(i => i?.ingridient?.name == kvp.Key)
                .Sum(i => i?.count ?? 0);

            if (availableCount < kvp.Value)
            {
                return false; // �� ������� ���������
            }
        }

        return true; // ���������� ���������
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
    public bool IsAdded(Item item, int count = 1)
    {
        if (inventory.Count < 12)
        {
            // ����������� ���������� ������ ��� ��������� � ����� �� ��������
            for (int i = 0; i < inventory.Count; i++)
            {
                if (item.ingridient == inventory[i].ingridient && inventory[i].count < 64 && inventory[i].status == item.status)
                {
                    inventory[i].count += count;
                    return true;
                }
            }

            // ������ ������ ���� � ���������
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].ingridient == null)
                {
                    inventory[i] = item;
                    inventory[i].count = count; // ������������� ���������� ������ ��������
                    return true;
                }
            }

            // ���� �� ����� ������������ ������� ��� ������ ����, ��������� ����� ������� � ����� ������
            item.count = count; // ������������� ���������� ������ ��������
            inventory.Add(item);
            return true;
        }
        return false;
    }
}
