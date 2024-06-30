using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<ShopSlot> slots = new List<ShopSlot>();
    public List<Item> items = new List<Item>();
    [SerializeField] Inventory playerInventory;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] GameObject message, messageInventory;

    private void Start()
    {
        Restart();
    }

    private void FixedUpdate()
    {
        moneyText.text = "Золотников: " + Player.money.ToString();
    }

    public void Restart()
    {
        slots = GetComponentsInChildren<ShopSlot>().ToList();

        for (int i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];

            if (i < items.Count)
            {
                slot.FillSlot(items[i]);
            }
            else
            {
                slot.FillSlot(null);
            }
        }
    }

    public void GetIndex(GameObject obj)
    {
        int index = obj.transform.GetSiblingIndex();
        Buy(index);
        StartCoroutine(Message());
    }

    private void Buy(int index)
    {
        int price = items[index].ingridient.price;

        if (Player.money >= price)
        {
            bool added = playerInventory.IsAdded(items[index]);
            if (added)
            {
                Player.money -= price;
            }
            else
            {
                messageInventory.SetActive(true);
            }
        }
        else
        {
            message.SetActive(true);
        }
    }

    private IEnumerator Message()
    {
        yield return new WaitForSeconds(5f);
        message.SetActive(false);
        messageInventory.SetActive(false);
    }
}
