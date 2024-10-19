namespace Ucu.Poo.RoleplayGame;

public abstract class MagicHeroe : Heroe

{
   public MagicHeroe(string name,int life, int attackValue, int defenseValue) : base(name, life, attackValue, defenseValue)
    {
        this.Name = name;
        this.health = life;
        this.DefenseValue = defenseValue; 
        this.AttackValue = attackValue;
    }
    private List<IMagicalItem> ItemsMagicos = new List<IMagicalItem>();
    public  void  AddItem(IMagicalItem ItemMagico)
    {
        this.ItemsMagicos.Add(ItemMagico);
    }

    void RemoveItem(IMagicalItem ItemMagico)
    {
     this.ItemsMagicos.Remove(ItemMagico);   
    }
}
