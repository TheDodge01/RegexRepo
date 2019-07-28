using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = (@">>([A-Za-z]+)<<([1-9]+\.?[0-9]+)!([0-9]+)");

            string command = Console.ReadLine();

            decimal totalPrice = 0;

            Console.WriteLine("Bought furniture:");

            while (command != "Purchase")
            {
                decimal priceForOnePurcahse = 0;
                
                MatchCollection matches = Regex.Matches(command, pattern);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[1].Value);

                    priceForOnePurcahse += decimal.Parse(match.Groups[2].Value);
                    priceForOnePurcahse = priceForOnePurcahse * decimal.Parse(match.Groups[3].Value);
                    totalPrice += priceForOnePurcahse;
                    priceForOnePurcahse = 0;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
