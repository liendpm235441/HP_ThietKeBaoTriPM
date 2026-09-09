// This file uses the code from code.cs
// To run the Flyweight Design Pattern example
using RefactoringGuru.DesignPatterns.Flyweight.Conceptual;

var factory = new FlyweightFactory(
    new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
    new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
    new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
    new Car { Company = "BMW", Model = "M5", Color = "red" },
    new Car { Company = "BMW", Model = "X6", Color = "white" }
);
factory.listFlyweights();

addCarToPoliceDatabase(factory, new Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "M5",
    Color = "red"
});

addCarToPoliceDatabase(factory, new Car
{
    Number = "CL234IR",
    Owner = "James Doe",
    Company = "BMW",
    Model = "X1",
    Color = "red"
});

factory.listFlyweights();

static void addCarToPoliceDatabase(FlyweightFactory factory, Car car)
{
    Console.WriteLine("\nClient: Adding a car to database.");
    var flyweight = factory.GetFlyweight(new Car
    {
        Company = car.Company,
        Model = car.Model,
        Color = car.Color
    });
    flyweight.Operation(car);
}
