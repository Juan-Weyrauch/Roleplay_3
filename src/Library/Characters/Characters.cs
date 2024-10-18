namespace Ucu.Poo.RoleplayGame;

public abstract class Characters
{
    protected int health = 100;
    
    protected List<IItem> Items = new List<IItem>();
    
    public  Characters(string name)
    {
        this.Name = name;
    }
    protected string Name { get; set; }

    public int AttackValue
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

    public int DefenseValue
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
    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
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

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }
}
