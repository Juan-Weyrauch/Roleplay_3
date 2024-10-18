using Library.Afiliacion;

namespace Ucu.Poo.RoleplayGame;

public abstract class Heroe : Characters
{
    protected List<IItem> Items = new List<IItem>();
    public Heroe(string name) : base(name)
    {
        this.Name = name;
    }
    public override int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }

            return value;
        }
    }

    public override int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }

            return value;
        }
    }
    public void AddItem(IItem item)
    {
        this.Items.Add(item);
    }
    public void RemoveItem(IItem item)
    {
        this.Items.Remove(item);
    }
    
    public void Cure()
    {
        this.Health = 100;
    }
    public void Checkcurar()
    {
        if (ValorVp == 5)
        {
            Cure();
            ValorVp = 0;
        }
    }

}

    
