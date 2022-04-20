using StadiumApp2.Data;
using StadiumApp2.Models;
using System;

namespace StadiumApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            bool check = true;
            string ans;
            do
            {
                Console.WriteLine("1. Stadion elave et");
                Console.WriteLine("2. Stadionlara bax");
                Console.WriteLine("3. Secilmis stadiona bax");
                Console.WriteLine("0. Sistemden cix");

                ans = Console.ReadLine();


                switch (ans)
                {
                    case "1":
                        Console.WriteLine("inser");
                        byte cap = 5;
                        decimal price = 45;
                        string name = "Zakir";

                        Stadium stadium = new Stadium
                        {
                            Capacity = cap,
                            Name = name,
                            HourlyPrice = price,
                        };

                        stadiumData.Add(stadium);
                        break;
                    case "2":


                        var stadiums = stadiumData.GetAll();

                        foreach (var item in stadiums)
                        {
                            Console.WriteLine(item.Id+" - "+item.Name+" - "+item.HourlyPrice);
                        }

                        break;
                    case "3":
                        Console.WriteLine("Id daxil et:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Stadium std = stadiumData.GetById(id);

                        Console.WriteLine(std.Name);
                        break;
                    case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Dogru secim edin:");
                        break;
                }

            } while (check);
        }
    }
}
