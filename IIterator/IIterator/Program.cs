using System.Collections;

namespace iterator;
public class Car
{
    public string Name { get; private set; }

    public Car(string name)
    {
        Name = name;
    }
}

public class Cars : IEnumerable
{
    private readonly Car[] cars;

    public Cars(Car[] cars)
    {
        this.cars = new Car[cars.Length];

        for (int i = 0; i < cars.Length; i++) 
        {
            this.cars[i] = cars[i];
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new CarsEnum(cars);
    }
}

public class CarsEnum : IEnumerator
{
    private readonly Car[] cars;

    public object Current => cars[position];

    private int position = -1;

    public CarsEnum(Car[] cars) 
    {
        this.cars = cars;
    }

    public bool MoveNext()
    {
        position++;
        return position < cars.Length;
    }

    public void Reset()
    {
        position = -1;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[3]
        {
            new Car("mazda"),
            new Car("honda"),
            new Car("bugatti")
        };

        Cars carsEnum = new(cars);

        foreach (Car car in carsEnum) 
        {
            Console.WriteLine(car.Name);
        }
    }
}
