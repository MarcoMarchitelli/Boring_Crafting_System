using UnityEngine;
using StateMachine;

public class Crafting_State_Main : StateBase
{
    CraftingContext context;

    public override IState Setup(IStateMachineContext _context)
    {
        context = _context as CraftingContext;
        return this;
    }
}