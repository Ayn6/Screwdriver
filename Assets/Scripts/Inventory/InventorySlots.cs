using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.XR;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    private List<InventorySlot> slots = new List<InventorySlot>();
    private bool click;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        slots = GetComponentsInChildren<InventorySlot>().ToList();

        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];

            if (i < playerInventory.inventory.Count)
            {
                slot.FillSlot(playerInventory.inventory[i]);
            }
            else
            {
                slot.FillSlot(null);
            }
        }

    }

    private int index; // ќбъ€вл€ем переменную уровн€ класса

    public void GetIndex(GameObject obj)
    {
        index = obj.transform.GetSiblingIndex();
        Debug.Log(index); // Ћогируем значение индекса
    }

    public void Delet()
    {
        Debug.Log(index);
        // ”бедитесь, что индекс установлен до вызова этого метода
        if (playerInventory.inventory[index].count <= 0)
        {
            return;
        }
        else
        {
            playerInventory.inventory[index].count--;
            Restart();
        }
    }
}
