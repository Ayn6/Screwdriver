using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Potion")]
public class Potion : ScriptableObject
{
    public Ingridient first;
    public Ingridient second;
    public Ingridient third;
    public Ingridient ready;
    public Sprite sprite;

    public float timeToCook;
    public float timeToReady;
}
