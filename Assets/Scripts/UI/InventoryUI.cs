using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public RectTransform itemsParent;

    [Header("UI")]
    public ItemUI itemUI;

    private void Awake()
    {
        if (inventory)
        {
            inventory.OnDataChanged += UpdateUI;
        }
    }

    public void UpdateUI()
    {
        if (!itemsParent)
        {
            Debug.LogError(name + " has no transform as items parent!");
            return;
        }

        for (int i = 0; i < itemsParent.childCount; i++)
        {
            Destroy(itemsParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < inventory.Items.Length; i++)
        {
            ItemUI iUI = Instantiate(itemUI, itemsParent);
            iUI.SetItem(inventory.Items[i]);
        }
    }
}