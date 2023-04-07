using ListLib;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ProgramNameSpace
{
    public class Program
    {
        //ГРУБО... Я ЗНАЮ. (ТАК ЛЕГЧЕ ЧИТАТЬ)
        private class Person
        {
            public string Name { get; set; }
            public Person(string name)
            {
                Name = name; 
            }

            public void Show()
            {
                Console.WriteLine(Name);
            }
        }
        }

        public static void Main()
        {
            GenList<Person> genListPerson = new GenList<Person>();
            for (int i = 0; i < 10; i++)
            { 
                genListPerson.Add(new Person($"Person {i}"));
            }
            foreach (var i in genListPerson)
            {
                i.Show();
            }
            genListPerson.Reset();
            
            GenList<int> genListInt = new GenList<int>();

            for (int i = 10; i > 0; i--)
            {
                genListInt.Add(i*i);
            }
            foreach (var i in genListInt)
            {
                Console.WriteLine($"INT {i}");
            }
            genListInt.Reset();
        }
    }
}