using System;

namespace strategy;

public interface IMoveBehavior
{
    void Move(IUnit unit);
}