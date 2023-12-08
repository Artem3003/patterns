using System;

namespace adapter;

public interface IDuck
{
    string Quack();
    void Fly();
}

public class Goose
{
    public string Honk()
    {
        return "Honk! Honk";
    }
    public void Fly() {}
}

public class GooseToIDuckAdapter : IDuck
{
    private readonly Goose goose;
    public GooseToIDuckAdapter(Goose goose)
    {
        this.goose = goose;
    }

    public void Fly()
    {
        goose.Fly();
    }

    public string Quack()
    {
        return goose.Honk();
    }
}