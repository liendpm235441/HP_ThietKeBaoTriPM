// This file uses the code from code.cs
// To run the Composite Design Pattern example
var client = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Client();

var leaf = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Leaf();
Console.WriteLine("Client: I get a simple component:");
client.ClientCode(leaf);

var tree = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Composite();
var branch1 = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Composite();
branch1.Add(new RefactoringGuru.DesignPatterns.Composite.Conceptual.Leaf());
branch1.Add(new RefactoringGuru.DesignPatterns.Composite.Conceptual.Leaf());
var branch2 = new RefactoringGuru.DesignPatterns.Composite.Conceptual.Composite();
branch2.Add(new RefactoringGuru.DesignPatterns.Composite.Conceptual.Leaf());
tree.Add(branch1);
tree.Add(branch2);
Console.WriteLine("Client: Now I've got a composite tree:");
client.ClientCode(tree);

Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
client.ClientCode2(tree, leaf);
