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
            // ���������, ���� �� ��� ����� ������� � ��������� item
            bool found = false;
            foreach (var existingItem in item)
            {
                if (existingItem.Equals(playerInventory.inventory[index].ingridient))
                {
                    // ���� ������� ��� ����, ����������� ��� ���������� �� 1
                    existingItem.count++;
                    found = true;
                    break;
                }
            }

            // ���� ������� �� ������, ��������� ��� � ��������� item
            if (!found)
            {
                item.Add(playerInventory.inventory[index].ingridient);
            }

            // ��������� ���������� � ��������� ������ � �������� Restart()
            playerInventory.inventory[index].count--;
            inventorySlots.Restart();
        }
    }
}
