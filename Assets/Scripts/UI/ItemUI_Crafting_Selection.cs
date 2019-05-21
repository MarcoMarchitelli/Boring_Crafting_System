using UnityEngine.UI;

public class ItemUI_Crafting_Selection : ItemUI
{
    Button _b;
    Button B
    {
        get
        {
            if (!_b)
                _b = GetComponent<Button>();
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