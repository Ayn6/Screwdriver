using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image imageItem;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private Sprite empty;

    public void FillSlot(Item item)
    {
        if (item == null || (item != null && item.count <= 0))
        {
            count.text = "";
            imageItem.sprite = empty;
        }
        else if (item != null)
        {
            if(item.status != 0)
            {
                Debug.Log(item.ingridient.ready);
                count.text = "x" + item.count.ToString();
                imageItem.sprite = item.ingridient.ready;
            }
            else
            {
                count.text = "x" + item.count.ToString();
                imageItem.sprite = item.ingridient.sprite;
            }

        }
    }
}
