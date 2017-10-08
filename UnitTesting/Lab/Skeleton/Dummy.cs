using Skeleton.Interfaces;
using System;

public class Dummy : ITarget
{
    private int health;
    private int keptExperience;

    public Dummy(int health, int keptExperience)
    {
        this.Healt = health;
        this.KeptExperience = keptExperience;
    }

    public int Healt
    {
        get
        {
            return this.health;
        }

        set
        {
            this.health = value;
        }
    }

    public int KeptExperience
    {
        get
        {
            return this.keptExperience;
        }

        set
        {
            this.keptExperience = value;
        }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.keptExperience;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }


}
