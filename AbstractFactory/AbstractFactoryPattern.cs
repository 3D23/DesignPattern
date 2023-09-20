namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args) 
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero warrior = new Hero(new WarriorFactory());
            warrior.Hit();
            warrior.Run();

            Console.ReadLine();
        }
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }

    abstract class Movement
    {
        public abstract void Move();
    }

    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

    class Sword : Weapon
    {
        public override void Hit() 
        {
            Console.WriteLine("Бьем мечом");
        }
    }

    class FlyMovement : Movement
    {
        public override void Move() 
        {
            Console.WriteLine("Летим");
        }
    }

    class RunMovement : Movement 
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    
    abstract class HeroFactory
    {
        public abstract Weapon CreateWeapon();
        public abstract Movement CreateMovement();
    }

    class ElfFactory : HeroFactory
    {
        public override Weapon CreateWeapon() => new Arbalet();
        
        public override Movement CreateMovement() => new FlyMovement();
    }

    class WarriorFactory : HeroFactory
    {
        public override Weapon CreateWeapon() => new Sword();

        public override Movement CreateMovement() => new RunMovement();
    }

    class Hero 
    {
        private Weapon _weapon;
        private Movement _movement;

        public Hero(HeroFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _movement = factory.CreateMovement();
        }

        public void Run()
        {
            _movement.Move();
        }

        public void Hit()
        {
            _weapon.Hit();
        }
    }
}