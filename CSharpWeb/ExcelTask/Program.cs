using System.Collections.Generic;

namespace ExcelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Person>
            {
                new Person("Василий", "Иванов", 33, "79612223456"),
                new Person("Иван", "Васильев", 35, "78965467833"),
                new Person("Марина", "Маринина", 30, "79996667788")
            };

            new ExcelGenerator().Generator(students);
        }
    }
}
