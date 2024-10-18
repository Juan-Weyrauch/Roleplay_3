namespace Ucu.Poo.RoleplayGame;

public abstract class MagicHeroe : Heroe

{
   public MagicHeroe(string name) : base(name)
    {
        this.Name = name;
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
