using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    [Header("UI")]
    public ItemUI itemUI;

    [HideInInspector] public ItemUI[] itemUIs;

    private void Awake()
    {
        if (inventory)
            inventory.OnSetup += Setup;
    }

    public void Setup()
    {
        if (inventory)
        {
            inventory.OnDataChanged += UpdateUI;
            itemUIs = new ItemUI[inventory.Items.Length];
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < inventory.Items.Length; i++)
        {
            ItemUI iUI = Instantiate(itemUI, transform);
            iUI.SetItem(inventory.Items[i]);
            itemUIs[i] = iUI;
        }
    }
}