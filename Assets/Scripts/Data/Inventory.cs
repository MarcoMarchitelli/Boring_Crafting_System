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
    public System.Action OnSetup;

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
            {
                Item item = Instantiate(startingItems[i], transform);
                Items[i] = item;
            }
            else
                Items[i] = null;
        }

        OnSetup?.Invoke();
    }

    public void AddItem(Item _item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = Instantiate(_item, transform);
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
                Destroy(Items[i].gameObject);
                Items[i] = null;
                break;
            }
        }
    }
}