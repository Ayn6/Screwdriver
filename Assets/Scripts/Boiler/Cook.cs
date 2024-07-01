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

            // Уменьшаем количество в инвентаре игрока и вызываем Restart()
            playerInventory.inventory[index].count--;
            inventorySlots.Restart();

            }
            else
            {
                Debug.Log("Неправильный ингридиет!");
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

                    // Создаем новый предмет со статусом 1
                    Item itemToAdd = new Item
                    {
                        ingridient = playerInventory.inventory[index].ingridient,
                        status = 1,
                        count = 1
                    };

                    // Проверяем, есть ли такой предмет в инвентаре со статусом 1
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

                    // Если предмет со статусом 1 не найден, добавляем его в инвентарь
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

                    // Создаем новый предмет со статусом 1
                    Item itemToAdd = new Item
                    {
                        ingridient = playerInventory.inventory[index].ingridient,
                        status = 1,
                        count = 1
                    };

                    // Проверяем, есть ли такой предмет в инвентаре со статусом 1
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

                    // Если предмет со статусом 1 не найден, добавляем его в инвентарь
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
            Debug.Log("Вы не можете толоч это растение");
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
            Debug.Log("Вы не можете сушить это растение");
            return;
        }
    }

    private IEnumerator Act(float time, Animator anim = null)
    {
        if (anim != null)
            anim.SetBool("Cook", true);

        yield return new WaitForSeconds(time);
        pound = true;
        Debug.Log("Готово");

        if (anim != null)
            anim.SetBool("Cook", false);
    }
}
