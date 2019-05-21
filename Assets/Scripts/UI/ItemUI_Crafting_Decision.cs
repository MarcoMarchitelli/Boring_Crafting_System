using UnityEngine.UI;

public class ItemUI_Crafting_Decision : ItemUI
{
    public Button craftButton;
    public Button cancelButton;

    private void Awake()
    {
        craftButton.onClick.AddListener(() => {
            MenuManager.Instance.Craft(item);
        });

        cancelButton.onClick.AddListener(() => {
            MenuManager.Instance.GoToMenu(MenuManager.MenuType.craftSelection);
        });
    }
}