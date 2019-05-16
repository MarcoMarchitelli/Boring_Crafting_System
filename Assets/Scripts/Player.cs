using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Statistics")]
    public int maxSteel;
    public int maxWood;
    public int maxLeather;
    public bool startsAtMax = true;

    [HideInInspector] public int currentSteel;
    [HideInInspector] public int currentWood;
    [HideInInspector] public int currentLeather;

    [Header("References")]
    public Inventory inventory;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        if (startsAtMax)
        {
            currentLeather = maxLeather;
            currentSteel = maxWood;
            currentWood = maxWood;
        }
    }
}