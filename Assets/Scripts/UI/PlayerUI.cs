using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Player player;

    [Header("UI")]
    public RectTransform materialsTransform;

    [Header("Prefabs References")]
    public ItemCostUI itemCostUIPrefab;

    public void SetPlayer(Player _p)
    {
        player = _p;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (materialsTransform)
        {
            for (int i = 0; i < materialsTransform.childCount; i++)
            {
                Destroy(materialsTransform.GetChild(i).gameObject);
            }

            foreach (ItemCost cost in player.materials)
            {
                ItemCostUI itemCostUI = Instantiate(itemCostUIPrefab, materialsTransform);
                itemCostUI.SetTarget(cost);
            }
        }
    }
}