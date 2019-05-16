using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public string displayName;
    public Sprite sprite;

    [Header("Materials")]
    public int steel;
    public int wood;
    public int leather;
}