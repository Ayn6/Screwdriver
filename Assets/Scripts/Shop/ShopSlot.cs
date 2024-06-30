using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField] private Image imageItem;
    [SerializeField] private TextMeshProUGUI count;
    [SerializeField] private Sprite empty;

    public void FillSlot(Item item)
    {
        if (item == null)
        {
            count.text = "";
            imageItem.sprite = empty;
        }
        else
        {
            count.text = item.ingridient.price.ToString();
            imageItem.sprite = item.ingridient.sprite;
        }

    }
}
