// This file uses the code from code.cs
// To run the Facade Design Pattern example
var subsystem1 = new RefactoringGuru.DesignPatterns.Facade.Conceptual.Subsystem1();
var subsystem2 = new RefactoringGuru.DesignPatterns.Facade.Conceptual.Subsystem2();
var facade = new RefactoringGuru.DesignPatterns.Facade.Conceptual.Facade(subsystem1, subsystem2);
RefactoringGuru.DesignPatterns.Facade.Conceptual.Client.ClientCode(facade);
