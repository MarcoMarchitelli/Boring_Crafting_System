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
        highlightImage.color = Color.gray;

        Button.onClick.AddListener(() => {
            if (item)
            {
                MenuManager.Instance.SelectItem(item);
            }
        });
    }

    public override void Select(bool _value)
    {
        selected = _value;
        highlightImage.color = selected ? Color.cyan : Color.gray;
    }
}