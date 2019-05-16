using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems;
    public Item[] startingItems;

    Item[] items;
    public Item[] Items
    {
        get
        {
            return items;
        }
        set
        {
            items = value;
            OnDataChanged?.Invoke();
        }
    }

    public System.Action OnDataChanged;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        Items = new Item[maxItems];

        for (int i = 0; i < items.Length; i++)
        {
            if (i <= startingItems.Length - 1)
                Items[i] = startingItems[i];
            else
                Items[i] = null;
        }
    }

}