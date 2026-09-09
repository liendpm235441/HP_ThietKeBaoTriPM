// This file uses the code from code.cs
// To run the Bridge Design Pattern example
var client = new RefactoringGuru.DesignPatterns.Bridge.Conceptual.Client();

RefactoringGuru.DesignPatterns.Bridge.Conceptual.Abstraction abstraction;
abstraction = new RefactoringGuru.DesignPatterns.Bridge.Conceptual.Abstraction(new RefactoringGuru.DesignPatterns.Bridge.Conceptual.ConcreteImplementationA());
client.ClientCode(abstraction);

Console.WriteLine();

abstraction = new RefactoringGuru.DesignPatterns.Bridge.Conceptual.ExtendedAbstraction(new RefactoringGuru.DesignPatterns.Bridge.Conceptual.ConcreteImplementationB());
client.ClientCode(abstraction);
