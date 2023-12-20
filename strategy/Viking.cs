using System;

namespace strategy;

public class Viking : IUnit
{
    public Viking()
    {
        MoveBehavior = new Walk();
    }

    public IMoveBehavior MoveBehavior { get; set; }

    public int Position { get; set; }

    public void Move()
    {
        MoveBehavior.Move(this);
    }
}