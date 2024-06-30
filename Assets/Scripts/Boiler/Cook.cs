using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Cook : MonoBehaviour
{

    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventorySlots inventorySlots;

    public List<Ingridient> item = new List<Ingridient>();
    private bool click = false, action = false, pound = false;
    private int index = 0;


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
                index = 0;
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
    public void Action()
    {
        if (playerInventory.inventory[index].count <= 0 || (index == 0 && !click))
        {
            if (action)
            {
                if (pound)
                {
                    Debug.Log(1);

                    // ������� ����� ������� �� �������� 1
                    Item itemToAdd = new Item
                    {
                        ingridient = playerInventory.inventory[index].ingridient,
                        status = 1,
                        count = 1
                    };

                    // ���������, ���� �� ����� ������� � ��������� �� �������� 1
                    bool itemAdded = false;
                    for (int i = 0; i < playerInventory.inventory.Count; i++)
                    {
                        if (playerInventory.inventory[i].ingridient == itemToAdd.ingridient && playerInventory.inventory[i].status == 1)
                        {
                            playerInventory.inventory[i].count += 1;
                            itemAdded = true;
                            break;
                        }
                    }

                    // ���� ������� �� �������� 1 �� ������, ��������� ��� � ���������
                    if (!itemAdded)
                    {
                        itemAdded = playerInventory.IsAdded(itemToAdd, 1);
                    }

                    if (!itemAdded)
                    {
                        Debug.LogWarning("Failed to add item to the inventory.");
                    }
                    pound = false;
                }
                else
                {
                    return;
                }
            }
            return;
        }
        else
        {
            if (action)
            {
                if (pound)
                {
                    Debug.Log(1);

                    // ������� ����� ������� �� �������� 1
                    Item itemToAdd = new Item
                    {
                        ingridient = playerInventory.inventory[index].ingridient,
                        status = 1,
                        count = 1
                    };

                    // ���������, ���� �� ����� ������� � ��������� �� �������� 1
                    bool itemAdded = false;
                    for (int i = 0; i < playerInventory.inventory.Count; i++)
                    {
                        if (playerInventory.inventory[i].ingridient == itemToAdd.ingridient && playerInventory.inventory[i].status == 1)
                        {
                            playerInventory.inventory[i].count += 1;
                            itemAdded = true;
                            break;
                        }
                    }

                    // ���� ������� �� �������� 1 �� ������, ��������� ��� � ���������
                    if (!itemAdded)
                    {
                        itemAdded = playerInventory.IsAdded(itemToAdd, 1);
                    }

                    if (!itemAdded)
                    {
                        Debug.LogWarning("Failed to add item to the inventory.");
                    }
                    pound = false;
                }
                else
                {
                    return;
                }
            }
            else
            {
                action = true;
                playerInventory.inventory[index].count--;
                inventorySlots.Restart();
                StartCoroutine(Pound(playerInventory.inventory[index].ingridient.time));
            }
        }
    }
    public void Pound()
    {
        if(playerInventory.inventory[index].ingridient.ctegory == 1)
        {
            Action();
        }
        else
        {
            Debug.Log("�� �� ������ ������ ��� ��������");
            return ;
        }
    }

    public void Drying()
    {
        if (playerInventory.inventory[index].ingridient.ctegory == 2)
        {
            Action();
        }
        else
        {
            Debug.Log("�� �� ������ ����� ��� ��������");
            return;
        }
    }

    private IEnumerator Pound(float time)
    {
        yield return new WaitForSeconds(5f);
        pound = true;
        Debug.Log(pound);
    }
}
