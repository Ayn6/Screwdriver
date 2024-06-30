using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Potion")]
public class Potion : ScriptableObject
{
    public List<Ingridient> ingridients = new List<Ingridient>();

    public Ingridient ready;
    public Sprite sprite;

    public float timeToCook;
    public float timeToReady;
}
