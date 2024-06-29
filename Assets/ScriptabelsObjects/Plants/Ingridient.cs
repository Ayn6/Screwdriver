using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Ingridient")]
public class Ingridient : ScriptableObject
{
    static int PLANT = 1;
    static int POTION = 2;

    public int count = 0;
    public string Name;
    public Sprite sprite;
    public int ctegory;
}

