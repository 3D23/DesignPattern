using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args) 
        {
            Developer dev = new PanelDeveloper("��� �����������");
            House house = dev.Create();

            dev = new WoodDeveloper("������� ����������");
            House house2 = dev.Create();

            Console.ReadLine();
        }
    }

    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }

        abstract public House Create();
    }

    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name) { }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name) { }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House { }

    class PanelHouse : House 
    {
        public PanelHouse()
        {
            Console.WriteLine("��������� ��� ��������");
        }
    }

    class WoodHouse : House 
    {
        public WoodHouse()
        {
            Console.WriteLine("���������� ��� ��������");
        }
    }
}