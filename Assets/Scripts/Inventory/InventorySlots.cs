using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    public Inventory playerInventory;
    private List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        // ������� �������� ���������, � ������� ���������� ����� 0
        playerInventory.inventory.RemoveAll(item => item.count == 0);

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

}
