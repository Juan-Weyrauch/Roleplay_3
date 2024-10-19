namespace Library.Afiliacion;

public abstract class Characters
 {
     protected int health = 100;
     public  Characters(string name)
     {
         this.Name = name;
     }
     
     public virtual int DefenseValue { get; set; }
     public virtual int AttackValue { get; set; }
     protected string Name { get; set; }
     protected  int ValorVp { get; set; }
 
     public int Health
     {
         get { return this.health; }
         protected set { this.health = value < 0 ? 0 : value; }
     }
     
 
     public void ReceiveAttack(int power)
     {
         if (this.DefenseValue < power)
         {
             this.Health -= power - this.DefenseValue;
         }
     }
     
     public virtual void ElminarCharacter(List<Characters> lista)
     {
         if (health == 0 && lista.Contains(this)) // metodo que permite eliminar un pj
         {
             lista.Remove(this);
         }
     }
     
 }