using UnityEngine.UI;
using UnityEngine;

public class ItemUI_In_Inventory : ItemUI
{
    public Image highlightImage;

    bool selected = false;
    Button _button;
    Button Button
    {
        get
        {
            if (!_button)
                _button = GetComponent<Button>();
            return _button;
        }
    }

    private void Awake()
    {
        Button.onClick.AddListener(() => {
            if (item)
            {
                selected = !selected;
                highlightImage.color = selected ? Color.cyan : Color.gray;
                MenuManager.Instance.SelectItem(item);
            }
        });
    }
}