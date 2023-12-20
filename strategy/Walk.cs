using System;

namespace strategy;

public class Walk : IMoveBehavior
{
    public void Move(IUnit unit)
    {
        unit.Position += 1;
    }
}