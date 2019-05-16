using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Player player;

    [Header("UI")]
    public TextMeshProUGUI steelText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI leatherText;

    private void Update()
    {
        UpdateUI();
    }

    public void SetPlayer(Player _p)
    {
        player = _p;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (steelText)
            steelText.text = player.currentSteel.ToString() + " / " + player.maxSteel.ToString();
        if (woodText)
            woodText.text = player.currentWood.ToString() + " / " + player.maxWood.ToString();
        if (leatherText)
            leatherText.text = player.currentLeather.ToString() + " / " + player.maxLeather.ToString();
    }
}