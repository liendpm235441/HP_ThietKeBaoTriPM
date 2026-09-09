// This file uses the code from code.cs
// To run the Decorator Design Pattern example
var client = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Client();

var simple = new RefactoringGuru.DesignPatterns.Composite.Conceptual.ConcreteComponent();
Console.WriteLine("Client: I've got a simple component:");
client.ClientCode(simple);
Console.WriteLine();

var decorator1 = new RefactoringGuru.DesignPatterns.Composite.Conceptual.ConcreteDecoratorA(simple);
var decorator2 = new RefactoringGuru.DesignPatterns.Composite.Conceptual.ConcreteDecoratorB(decorator1);
Console.WriteLine("Client: Now I've got a decorated component:");
client.ClientCode(decorator2);
