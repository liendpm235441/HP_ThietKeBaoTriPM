// This file uses the code from code.cs
// To run the Proxy Design Pattern example
var client = new RefactoringGuru.DesignPatterns.Proxy.Conceptual.Client();

Console.WriteLine("Client: Executing the client code with a real subject:");
var realSubject = new RefactoringGuru.DesignPatterns.Proxy.Conceptual.RealSubject();
client.ClientCode(realSubject);

Console.WriteLine();

Console.WriteLine("Client: Executing the same client code with a proxy:");
var proxy = new RefactoringGuru.DesignPatterns.Proxy.Conceptual.Proxy(realSubject);
client.ClientCode(proxy);
