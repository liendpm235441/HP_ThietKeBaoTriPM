// This file uses the code from code.cs
// To run the Adapter Design Pattern example, the Main method from code.cs will be executed
var adaptee = new RefactoringGuru.DesignPatterns.Adapter.Conceptual.Adaptee();
var target = new RefactoringGuru.DesignPatterns.Adapter.Conceptual.Adapter(adaptee);

Console.WriteLine("Adaptee interface is incompatible with the client.");
Console.WriteLine("But with adapter client can call it's method.");
Console.WriteLine(target.GetRequest());
