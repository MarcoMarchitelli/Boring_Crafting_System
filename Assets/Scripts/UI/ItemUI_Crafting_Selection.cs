public class ItemUI_Crafting_Selection : ItemUI
{
    CustomButton _b;
    CustomButton B
    {
        get
        {
            if (!_b)
                _b = GetComponent<CustomButton>();
            return _b;
        }
    }

    private void Awake()
    {
        B.onClick.AddListener(() => {
            MenuManager.Instance.OpenCraftDecisionMenu(item);
        });
    }
}