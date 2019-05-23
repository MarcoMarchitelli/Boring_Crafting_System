using UnityEngine;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    public static int GlobalID = 0;

    public int ID;
    public string displayName;
    public Sprite sprite;

    public List<ItemCost> costs;
}