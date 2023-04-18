using SingletonProject;
Console.Title = "Singleton Pattern";

//call the property getter mice 
var instance1 = Project.Instance;
var instance2 = Project.Instance;

if (instance1 == instance2 && instance2 == Project.Instance)
{
    Console.WriteLine("Instances are the Same.");
}