using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]

[Serializable]
public class Item
{
    public Ingridient ingridient;
    public int count;
    public int status = 0;
}
