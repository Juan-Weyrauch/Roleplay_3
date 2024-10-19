namespace Library.Afiliacion;

public abstract class Characters
 {
     protected int health = 100;
     public  Characters(string name)
     {
         this.Name = name;
     }

     protected Characters Killer; 
     public virtual int DefenseValue { get; set; }
     public virtual int AttackValue { get; set; }
     protected string Name { get; set; }
     protected  int ValorVp { get; set; }
 
     public int Health
     {
         get { return this.health; }
         protected set { this.health = value < 0 ? 0 : value; }
     }

     public void Attack(Characters target)
     {
         target.ReceiveAttack(this);
     }
 
     public void ReceiveAttack(Characters attacker)
     {
         if (this.DefenseValue < attacker.AttackValue)
         {
             this.Health -= attacker.AttackValue - this.DefenseValue;
         }

         if (this.Health <= 0)
         {
             this.Killer = attacker;
         }
     }

     public int Obtenervida()
     {
         return health;
     }

     public string ObtenerNombre()
     {
         return Name;
     }
     public string ObtenerNombreAsesino()
     {
         return Killer.ObtenerNombre();
     }

     
     
     
 }