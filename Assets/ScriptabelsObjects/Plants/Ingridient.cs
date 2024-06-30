using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Ingridient")]
public class Ingridient : ScriptableObject
{
    public int count = 0;
    public string Name;
    public Sprite sprite;
    public Sprite ready;
    public int ctegory;
    public float time;


    public bool open;
}

