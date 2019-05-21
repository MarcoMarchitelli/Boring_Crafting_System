using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems;
    public Item[] startingItems;

    Item[] _items;
    public Item[] Items
    {
        get
        {
            return _items;
        }
        set
        {
            _items = value;
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

        for (int i = 0; i < Items.Length; i++)
        {
            if (i <= startingItems.Length - 1)
                Items[i] = startingItems[i];
            else
                Items[i] = null;
        }
    }

    public void AddItem(Item _item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = _item;
                break;
            }
        }
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == _item)
            {
                Items[i] = null;
                break;
            }
        }
    }
}