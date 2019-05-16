using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Item item;

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI steelText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI leatherText;

    private void Update()
    {
        UpdateUI();
    }

    public void SetItem(Item _i)
    {
        item = _i;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(image)
            image.sprite = item == null ? null : item.sprite;
        if (nameText)
            nameText.text = item.displayName;
        if (steelText)
            steelText.text = item.steel.ToString();
        if (woodText)
            woodText.text = item.wood.ToString();
        if (leatherText)
            leatherText.text = item.leather.ToString();
    }

}