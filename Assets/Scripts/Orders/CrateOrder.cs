
using TMPro;
using UnityEngine;

public class CrateOrder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    public void Create(Ingridient item, int count)
    {
      countText.text = item.Name + " x" + count.ToString();  
    }

    public void Clear()
    {
        countText.text = "";
    }
}
