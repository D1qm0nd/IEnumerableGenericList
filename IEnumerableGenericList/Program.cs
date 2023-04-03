using ListLib;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ProgramNameSpace
{
    public class Program
    {

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

        public static void Main()
        {

            GenList<Person> genList = new GenList<Person>();
            for (int i = 0; i < 100; i++)
            { 
                genList.Add(new Person($"{i} Person"));
            }
            foreach (var i in genList)
            {
                i.Show();
            }
            Console.WriteLine();
            genList.Reset();

            foreach (var i in genList)
            {
                i.Show();
            }
        }
    }
}