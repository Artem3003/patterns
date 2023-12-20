using System;

namespace strategy;

public interface IUnit
{
    int Position { get; set; }
    void Move();
    IMoveBehavior MoveBehavior { get; set; }
}