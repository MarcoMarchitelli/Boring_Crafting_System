using UnityEngine.UI;

public class ItemUI_Dismantle : ItemUI
{
    public Button dismantleButton;

    private void Awake()
    {
        dismantleButton.onClick.AddListener(() => { MenuManager.Instance.Dismantle(); });
    }
}