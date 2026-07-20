using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
        
            // Task 1

            int age = 21;
            double gpa = 87.7;
            bool pass = true;

            string name = "Lubna";
            int[] numbers = { 1, 2, 3 };
            object obj = new object();

            Console.WriteLine(age.GetType().Name);
            Console.WriteLine(gpa.GetType().Name);
            Console.WriteLine(pass.GetType().Name);
            Console.WriteLine(name.GetType().Name);
            Console.WriteLine(numbers.GetType().Name);
            Console.WriteLine(obj.GetType().Name);

            Console.WriteLine();

            
            // Task 2
            

            DemonstrateCopyBehavior();

            Console.WriteLine();

            
            // Task 3
            Console.WriteLine(DescribeGrade(95));
            Console.WriteLine(DescribeGrade(80));
            Console.WriteLine(DescribeGrade(60));
            Console.WriteLine(DescribeGrade(30));   


            Console.WriteLine();

            
            // Task 4
            

            Console.Write("Enter your name: ");
            string? name1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name1))
            {
                Console.WriteLine("Name cannot be empty.");
            }
            else
            {
                Console.WriteLine($"Hello, {name1}!");
            }
        }

        static void DemonstrateCopyBehavior()
        {
            Console.WriteLine(" Value Type ");

            int x = 10;
            int y = x;

            Console.WriteLine("Before :");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");

            y = 20;

            Console.WriteLine("After :");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");

            Console.WriteLine();

            Console.WriteLine(" Reference Type ");

            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = numbers1;

            Console.WriteLine("Before :");
            Console.WriteLine($"numbers1[0] = {numbers1[0]}");
            Console.WriteLine($"numbers2[0] = {numbers2[0]}");

            numbers2[0] = 100;

            Console.WriteLine("After :");
            Console.WriteLine($"numbers1[0] = {numbers1[0]}");
            Console.WriteLine($"numbers2[0] = {numbers2[0]}");
        }

      static string DescribeGrade(int score)
{
    return score switch
    {
        >= 90 => "Excellent",
        >= 70 => "Proficient",
        >= 50 => "Developing",
        _ => "Below Standard"
    };
}
    }
}