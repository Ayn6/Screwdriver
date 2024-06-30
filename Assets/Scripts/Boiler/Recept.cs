using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Recept : MonoBehaviour
{
    [SerializeField] private Potion potion;
    [SerializeField] private Cook inventorySlots;
    [SerializeField] private Inventory playerInventory;

    private Item item;

    public List<Potion> items = new List<Potion>();

    private bool click = false;
    private int index = -1;

    private void FixedUpdate()
    {
        if (inventorySlots.item.Count != 0)
        {
            // Используем минимальный размер списка для предотвращения выхода за границы
            int minCount = Mathf.Min(inventorySlots.item.Count, potion.ingridients.Count);

            for (int i = 0; i < minCount; i++)
            {
                if (inventorySlots.item[i].ingridient != potion.ingridients[i])
                {
                    Debug.Log("Неправильный ингридиет!");
                    inventorySlots.item.Clear();
                    break; // Прерываем цикл после очистки списка, чтобы избежать дальнейших ошибок
                }
            }
        }
    }
    public void Cooking()
    {
        for (int i = 0; i < inventorySlots.item.Count; i++)
        {
            if (inventorySlots.item[i].ingridient != potion.ingridients[i])
            {
                Debug.Log("Неправильный ингридиет!");
                inventorySlots.item.Clear();
            }
            else
            {
                StartCoroutine(Create(potion.timeToReady));
            }
        }
    }


    public void GetIndex(GameObject obj)
    {
        if (click)
        {
            if (index != obj.transform.GetSiblingIndex())
            {
                click = true;
                potion = items[index];
            }
            else
            {
                index = -1;
                click = false;
                potion = null;
            }

        }
        else
        {
            click = true;
            index = obj.transform.GetSiblingIndex();
            potion = items[index];
        }
    }

    private IEnumerator Create(float time)
    {
        yield return new WaitForSeconds(5);
        item = new Item
        {
            ingridient = potion.ready
        };
        inventorySlots.item.Clear();
        playerInventory.IsAdded(item);
        Debug.Log("Готово");
    }
}
