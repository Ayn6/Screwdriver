using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour
{
    private List<CrateOrder> slotsOrders = new List<CrateOrder>();
    public List<Item> orders = new List<Item>();
    private List<int> countItem = new List<int>();

    [SerializeField] private Inventory playerInvetory;

    public List<Item> items = new List<Item>();

    private void Start()
    {
        UpdateOrder();
    }
    public void UpdateOrder()
    {
        // Очищаем слоты
        foreach (var slot in GetComponentsInChildren<CrateOrder>())
        {
            if (slot != null) // Проверка на null
            {
                slot.Clear();
            }
        }

        orders.Clear();
        countItem.Clear();

        slotsOrders = GetComponentsInChildren<CrateOrder>().ToList();

        Dictionary<Item, bool> usedItem = new Dictionary<Item, bool>();
        List<Item> availableItems = items.Where(item => item.ingridient != null && item.ingridient.ctegory == 3).ToList();

        if (availableItems.Count == 0)
        {
            Debug.LogWarning("No available items to create orders.");
            return;
        }

        int slotCount = Random.Range(1, availableItems.Count + 1); // Исправлено с 0 на 1
        for (int i = 0; i < slotCount && i < slotsOrders.Count; i++)
        {
            var slot = slotsOrders[i];

            int index = Random.Range(0, availableItems.Count);
            Item select = availableItems[index];

            while (usedItem.ContainsKey(select))
            {
                index = Random.Range(0, availableItems.Count);
                select = availableItems[index];
            }

            usedItem.Add(select, true);
            int count = Random.Range(1, 5);

            if (slot != null && select.ingridient != null) // Проверка на null
            {
                slot.Create(select.ingridient, count);
                orders.Add(select);
                countItem.Add(count);
            }
        }

        if (orders.Count == 0 || countItem.Count == 0)
        {
            Debug.LogWarning("Failed to generate valid orders. Retrying...");
            UpdateOrder();
        }
    }


    public void CompleteOrder()
    {
        slotsOrders = GetComponentsInChildren<CrateOrder>().ToList();
        bool enoughItems = playerInvetory.IsEnoughtItem(orders);
        int money = 0;

        if (enoughItems)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                Item order = orders[i];
                int requiredCount = countItem[i];
                money += order.ingridient.price * requiredCount;
                bool action = playerInvetory.RemoveItem(order.ingridient.name, requiredCount);
                if (!action)
                {
                    Debug.LogError($"Failed to remove item: {order.ingridient.name}");
                    break;
                }
            }
            
            Player.money += money;
            UpdateOrder();
        }
        else
        {
            Debug.LogWarning("Not enough items to complete the order.");
        }
    }
}
