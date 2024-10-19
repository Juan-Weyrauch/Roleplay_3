namespace Ucu.Poo.RoleplayGame;

public abstract class Characters
 {
     protected int health = 100;
     public  Characters(string name)
     {
         this.Name = name;
     }
     
     public virtual int DefenseValue { get; set; }
     public virtual int AttackValue { get; set; }
     public string Name { get;protected set; }
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

     }
     
     public string ObtenerNombre()
     {
         return Name;
     }
 }