using System;

namespace adapter;

public class Target
{
    public int Health { get; set; }
}

public interface IUnit
{
    void Attack(Target target);
}

public class Marine : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 6;
    }
}

public class Zealot : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 8;
    }
}

public class Zergling : IUnit
{
    public void Attack(Target target)
    {
        target.Health -= 5;
    }
}

public class Mario
{
    public int JumpAttack()
    {
        System.Console.WriteLine("Mamamio!");
        return 3;
    }
}

// Adapter
public class MarioAdapter : IUnit
{
    private readonly Mario mario;
    public MarioAdapter(Mario mario)
    {
        this.mario = mario;
    }
    public void Attack(Target target)
    {
        target.Health -= mario.JumpAttack();
        
    }
}