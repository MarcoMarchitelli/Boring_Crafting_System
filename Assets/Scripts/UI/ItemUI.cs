using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public Item item;

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI nameText;
    public RectTransform costsTransform;

    [Header("Prefabs References")]
    public ItemCostUI itemCostUIPrefab;

    private void Update()
    {
        UpdateUI();
    }

    public void SetItem(Item _i)
    {
        item = _i;
        UpdateUI();
    }

    public virtual void UpdateUI()
    {
        if (image)
        {
            image.sprite = item == null ? null : item.sprite;
            image.color = item == null ? Color.clear : Color.white;
        }
        if (nameText)
            nameText.text = item.displayName;
        if (costsTransform)
        {
            for (int i = 0; i < costsTransform.childCount; i++)
            {
                Destroy(costsTransform.GetChild(i).gameObject);
            }

            foreach (ItemCost cost in item.costs)
            {
                ItemCostUI itemCostUI = Instantiate(itemCostUIPrefab, costsTransform);
                itemCostUI.SetTarget(cost);
            }
        }
    }

    public virtual void Select(bool _value)
    {

    }
}