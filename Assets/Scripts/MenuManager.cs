using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Data")]
    public InventoryUI playerInventoryUI;
    public PlayerUI playerUI;

    [Header("UI")]
    public CustomButton craftButton;
    public CustomButton dismantleButton;
    public Menu craftSelectionMenu;
    public Menu craftDecisionMenu;
    public Menu dismantleMenu;

    Item selectedItem;

    public enum MenuType { main, craftSelection, craftDecision, dismantle }
    MenuType currentMenu;

    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        playerUI.UpdateUI();
    }

    private void Start()
    {
        GoToMenu(MenuType.main);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (currentMenu)
            {
                case MenuType.main:
                    break;
                case MenuType.dismantle:
                case MenuType.craftSelection:
                    GoToMenu(MenuType.main);
                    break;
                case MenuType.craftDecision:
                    GoToMenu(MenuType.craftSelection);
                    break;     
            }
        }
    }

    public void SelectItem(Item _item)
    {
        selectedItem = _item;
        dismantleButton.SetActive(true);
    }

    public void OpenCraftSelectionMenu()
    {
        GoToMenu(MenuType.craftSelection);
    }

    public void OpenCraftDecisionMenu(Item _item)
    {
        GoToMenu(MenuType.craftDecision);
        craftDecisionMenu.GetComponent<ItemUI>().SetItem(_item);
    }

    public void OpenDismantleMenu()
    {
        if (selectedItem)
        {
            GoToMenu(MenuType.dismantle);
            dismantleMenu.GetComponent<ItemUI>().SetItem(selectedItem);
        }
    }

    public void Dismantle()
    {
        foreach (ItemCost cost in selectedItem.costs)
        {
            foreach (ItemCost material in playerUI.player.materials)
            {
                if (material.material == cost.material)
                {
                    material.amount += cost.amount;
                    //should be itemcost business
                    if (material.amount > material.maxAmount)
                        material.amount = material.maxAmount;
                }
            }
        }

        playerUI.UpdateUI();
        playerInventoryUI.inventory.RemoveItem(selectedItem);
        playerInventoryUI.UpdateUI();
        GoToMenu(MenuType.main);

        selectedItem = null;
    }

    public void Craft(Item _item)
    {
        foreach (ItemCost cost in _item.costs)
        {
            foreach (ItemCost material in playerUI.player.materials)
            {
                if (material.material == cost.material)
                    if (material.amount >= cost.amount)
                    {
                        material.amount -= cost.amount;
                    }
                    else
                        return;
            }
        }

        playerUI.UpdateUI();
        playerInventoryUI.inventory.AddItem(_item);
        playerInventoryUI.UpdateUI();
        GoToMenu(MenuType.main);
    }

    public void GoToMenu(MenuType _menuToGoTo)
    {
        currentMenu = _menuToGoTo;
        switch (currentMenu)
        {
            case MenuType.main:
                craftButton.SetActive(true);
                dismantleButton.SetActive(false);
                craftDecisionMenu.gameObject.SetActive(false);
                craftSelectionMenu.gameObject.SetActive(false);
                dismantleMenu.gameObject.SetActive(false);
                break;
            case MenuType.craftSelection:
                craftButton.SetActive(false);
                dismantleButton.SetActive(false);
                craftDecisionMenu.gameObject.SetActive(false);
                craftSelectionMenu.gameObject.SetActive(true);
                break;
            case MenuType.craftDecision:
                craftButton.SetActive(false);
                dismantleButton.SetActive(false);
                craftDecisionMenu.gameObject.SetActive(true);
                break;
            case MenuType.dismantle:
                craftButton.SetActive(false);
                dismantleButton.SetActive(false);
                dismantleMenu.gameObject.SetActive(true);
                dismantleMenu.GetComponent<ItemUI>().SetItem(selectedItem);
                break;
        }
    }
}