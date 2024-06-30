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
    [SerializeField] private RectTransform scale;
    private Item item;

    private bool isCoroutineRunning = false;

    private void FixedUpdate()
    {
        if (inventorySlots.item.Count != 0 && !isCoroutineRunning)
        {
            StartCoroutine(Between());
        }
    }
    public void Cooking()
    {
        if (inventorySlots.item[0] == potion.first && inventorySlots.item[1] == potion.second && inventorySlots.item[2] == potion.third)
        {
            inventorySlots.item.Clear();

            item = new Item
            {
                ingridient = potion.ready,
                count = 1
            };

            playerInventory.inventory.Add(item);
        }
        else
        {
            inventorySlots.item.Clear();
        }
    }

    private IEnumerator Between()
    {
        isCoroutineRunning = true;
        Debug.Log("Coroutine started.");

        // Выполнение действий в течение 5 секунд
        float elapsedTime = 0f;
        float time = potion.timeToCook;
        while (elapsedTime < time)
        {
            float expUI = time / 400f;
            scale.localScale = new Vector3(expUI, 1, 1);
            Debug.Log("While loop iteration, elapsed time: " + elapsedTime);

            yield return new WaitForSeconds(1); // Пауза между итерациями
            elapsedTime += 1f;
        }

        Debug.Log("5 seconds elapsed. Clearing items.");
        inventorySlots.item.Clear();
        Debug.Log("Items cleared, item count: " + inventorySlots.item.Count);

        isCoroutineRunning = false;
        Debug.Log("Coroutine ended.");
    }
}
