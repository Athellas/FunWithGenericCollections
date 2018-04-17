using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            UseGenericList();
            UseGenericStack();
            UseGenericQueue();
            UseSortedSet();
            Console.ReadLine();
        }

        static void UseGenericList()
        {
            // Make a List of Person objects, filled with
            // collection/object init syntax.
            List<Person> people = new List<Person>()
            {
                new Person {FirstName = "Homer", LastName = "Simpson", Age = 47},
                new Person {FirstName = "Marge", LastName = "Simpson", Age = 45},
                new Person {FirstName = "Lisa", LastName = "Simpson", Age = 9},
                new Person {FirstName = "Bart", LastName = "Simpson", Age = 8}
            };

            // Print out # of items in List.
            Console.WriteLine("Items in list: {0}", people.Count);

            // enumerate over list
            foreach (Person p in people)
                Console.WriteLine(p);

            // Insert a new person
            Console.WriteLine("\n->Inserting new person.");
            people.Insert(2, new Person {FirstName = "Maggie", LastName = "Simpson", Age = 2});
            Console.WriteLine("Items in list: {0}", people.Count);

            // Copy data into a new array
            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++)
            {
                Console.WriteLine("First Names: {0}", arrayOfPeople[i].FirstName);
            }
        }

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });

            // Now look at the top item, pop it, and look again.
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person item is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());

            try
            {
                Console.WriteLine("\nnFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message);
            }
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }

        static void UseGenericQueue()
        {
            //Make a Q with 3 ppl
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson",Age = 47 });
            peopleQ.Enqueue(new Person { FirstName = "Marge",LastName = "Simpson",Age = 45 });
            peopleQ.Enqueue(new Person { FirstName = "Lisa",LastName = "Simpson",Age = 9 });

            //peek first p in q
            Console.WriteLine($"{peopleQ.Peek().FirstName} is the first in line!");

            //remove
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());

            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message);
            }
        }

        static void UseSortedSet()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };

            // note that items are sorted by age
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // add a few new people with various ages
            setOfPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setOfPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });

            //still sorted by age!
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }
    }
}
