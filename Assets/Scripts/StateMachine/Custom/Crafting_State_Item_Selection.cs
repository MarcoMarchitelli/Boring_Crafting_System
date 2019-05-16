using UnityEngine;
using StateMachine;

public class Crafting_State_Item_Selection : StateBase
{
    CraftingContext context;

    public override IState Setup(IStateMachineContext _context)
    {
        context = _context as CraftingContext;
        return this;
    }
}