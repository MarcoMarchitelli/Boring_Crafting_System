using UnityEngine;
using StateMachine;

public class CraftingStateMachine : StateMachineBase
{
    public CraftingContext craftingContext;

    protected override IStateMachineContext ContextSetup()
    {
        return craftingContext;
    }
}

[System.Serializable]
public class CraftingContext : IStateMachineContext
{
    public Inventory playerInventory;
    public Inventory craftingInventory;
}