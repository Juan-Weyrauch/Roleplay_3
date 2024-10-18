namespace Ucu.Poo.RoleplayGame;

public class Staff: AttackItem, IDefenseItem
{
    public int AttackValue
    {
        get
        {
            return 100;
        }
    }

    public int DefenseValue
    {
        get
        {
            return 100;
        }
    }
}
