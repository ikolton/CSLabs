using System;
using System.Runtime.ConstrainedExecution;

namespace Zad3_0
{
    internal class zad3_0
    {
        // public static void Main(string[] args)
        // {
        //     //initialize person with name and second name
        //     Person person = new Person();
        //     person.Name = "Jan";
        //     person.SecondName = "Nowak";
        //     Console.WriteLine(person.Name + " " + person.SecondName);
        //     ChangeName1(person);
        //     Console.WriteLine(person.Name + " " + person.SecondName);
        //     ChangeName2(ref person);
        //     Console.WriteLine(person.Name + " " + person.SecondName);
        //     ChangeName3(ref person);
        //     if(person == null)
        //         Console.WriteLine("Person is null");
        //     else
        //         Console.WriteLine(person.Name + " " + person.SecondName);
        // }
        
        public static void ChangeName1(Person person)
        {
            person.Name = "Edward";
            person.SecondName = "Szczyt";
        }
        
        public static void ChangeName2(ref Person person)
        {
            person = new Person();
            person.Name = "Edward";
            person.SecondName = "Góra";
        }

        public static void ChangeName3(ref Person person)
        {
            person = null;
        }
    }
    
    //person class with Nam and SecondName
    public class Person
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
    
    //method changing Person's name and second name
    
    
    
}