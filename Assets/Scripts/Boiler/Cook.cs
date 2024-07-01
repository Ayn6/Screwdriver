using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventorySlots inventorySlots;
    [SerializeField] private Animator animD;
    [SerializeField] private Animator animM;

    public List<Item> item = new List<Item>();
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
        if (playerInventory.inventory[index].count <= 0 || (index == 0 && !click))
        {
            return;
        }
        else
        {
            if(playerInventory.inventory[index].status != 0)
            {                
                Item newItem = new Item
                {
                    ingridient = playerInventory.inventory[index].ingridient,
                    status = playerInventory.inventory[index].status,
                    count = 1
                };
                item.Add(newItem);

            // ��������� ���������� � ��������� ������ � �������� Restart()
            playerInventory.inventory[index].count--;
            inventorySlots.Restart();

            }
            else
            {
                Debug.Log("������������ ���������!");
            }

        }
    }

    public void Action(Animator animator = null)
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
                    action = false;
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
                    action = false;
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
                StartCoroutine(Act(playerInventory.inventory[index].ingridient.time, animator));
            }
        }
    }
    public void Pound()
    {
        if(playerInventory.inventory[index].ingridient.ctegory == 1 && playerInventory.inventory[index].status == 0)
        {
            Action(animM);
        }
        else
        {
            Debug.Log("�� �� ������ ����� ��� ��������");
            return ;
        }
    }

    public void Drying()
    {
        if (playerInventory.inventory[index].ingridient.ctegory == 2)
        {
            Action(animD);
        }
        else
        {
            Debug.Log("�� �� ������ ������ ��� ��������");
            return;
        }
    }

    private IEnumerator Act(float time, Animator anim = null)
    {
        if (anim != null)
            anim.SetBool("Cook", true);

        yield return new WaitForSeconds(time);
        pound = true;
        Debug.Log("������");

        if (anim != null)
            anim.SetBool("Cook", false);
    }
}
