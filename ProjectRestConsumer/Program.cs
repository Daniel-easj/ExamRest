using System;
using System.Threading;
using InnoLib;

namespace ProjectRestConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Project project = new Project(5,"TestProjectName", "TestProjectCategory", 11);
            
           RestConsumer rConsumer = new RestConsumer();

            // GetAll
            Console.WriteLine("All objects:");
            foreach (Project projectObj in rConsumer.GetAll())
            {
                Console.WriteLine(projectObj);
            }

            // GetByID
            Console.WriteLine("Object with ID = 2:");
            Console.WriteLine(rConsumer.GetOne(2));

            // POST
            Console.WriteLine($"Attempts to create object: {project}:");
            Console.WriteLine(rConsumer.Post(project));
            Console.WriteLine("Prints new total object list:");
            foreach (Project projectObj in rConsumer.GetAll())
            {
                Console.WriteLine(projectObj);
            }

            Console.ReadKey();
        }
    }
}
