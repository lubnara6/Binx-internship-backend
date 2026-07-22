using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    Dictionary<int,string> names = new Dictionary<int, string>();
    names.Add(989,"lubna");
    names.Add(5454,"Ali");
    names.Add(984,"Samer");

    foreach(var item in names)
        {
            Console.WriteLine($"the key value is{item.Key}");
        }




    }
}