using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    private List<InventorySlot> slots = new List<InventorySlot>();
    private int index;

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

    public void GetIndex(GameObject obj)
    {

        index = obj.transform.GetSiblingIndex();
    }

    public void OnMouseDown()
    {
        Debug.Log(1);
        if(playerInventory.inventory[index].count <= 0)
        {
            return;
        }
        else
        {
            playerInventory.inventory[index].count --; 
            Restart();
        }

    }
}
