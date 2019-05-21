using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCostUI : MonoBehaviour
{
    public ItemCost target;
    public bool displayMaxAmount;
    public bool displayMaterialName;

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI text;

    public void SetTarget(ItemCost _target)
    {
        target = _target;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (image)
            image.color = target.material.color;
        if (text)
        {
            if ( displayMaterialName && displayMaxAmount )
                text.text = target.amount.ToString() + "/" + target.maxAmount.ToString() + " " + target.material.name;
            else if ( displayMaxAmount )
                text.text = target.amount.ToString() + "/" + target.maxAmount.ToString();
            else if( displayMaterialName )
                text.text = target.amount.ToString() + " " + target.material.name;
            else
                text.text = target.amount.ToString();
        }
    }
}