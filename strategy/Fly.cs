using System;

namespace strategy;

public class Fly : IMoveBehavior
{
    public void Move(IUnit unit)
    {
        unit.Position += 10;
    }
}