using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day10.ExtentionFuns;
using static Day10.ListGenerators;
using System.IO;

namespace Day10
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK 1");
            var Result = from P in ProductList
                         where P.UnitsInStock == 0
                         group P by P.Category;
            foreach (var i in Result)
            {
                foreach (var j in i)
                    Console.WriteLine($"{j.ProductID}");
            }

            Console.WriteLine("TASK 2");
            Result = from P in ProductList
                     where P.UnitsInStock > 0
                     where P.UnitPrice > 3.00m
                     group P by P.Category;

            foreach (var i in Result)
            {
                foreach (var j in i)
                    Console.WriteLine($"{j}");
            }
            Console.WriteLine("TASK 3");

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var res = Arr.Where((D, i) => D.Length < i);
            foreach (var i in res)
            {
                Console.WriteLine($"{i}");
            }

            var h = (from P in ProductList
                     where P.UnitsInStock == 0
                     select P).First();

            Console.WriteLine(h);
            h = (from P in ProductList
                 where P.UnitPrice > 1000m
                 select P).FirstOrDefault();
            Console.WriteLine(h);

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var ergregreg = arr.OrderByDescending(r => r).Skip(1).FirstOrDefault();
            Console.WriteLine(ergregreg);

            var catnms = ProductList.Select(P => P.Category).Distinct();

            foreach (var i in catnms)
            {
                Console.WriteLine($"{i}");
            }

            var prodlist = ProductList.Select(P => P.Category[0]);
            var customerloist = CustomerList.Select(C => C.CustomerID[0]);
            var bothlist = prodlist.Union(customerloist);

            foreach (var i in bothlist)
                Console.WriteLine($"{i}");

            var firstcommon = customerloist.Intersect(prodlist);

            foreach (var i in firstcommon)
                Console.WriteLine($"{i}");

            var commonuniq = prodlist.Except(customerloist);

            foreach (var i in commonuniq)
                Console.WriteLine($"{i}");

            var prodlast = ProductList.
            Select(P => (P.ProductName.Substring(P.ProductName.Length - 3)));
            var customerlast = CustomerList
                .Select(C => ((C.CustomerID.Substring(C.CustomerID.Length - 3))));

            var threes = prodlast.Concat(customerlast);

            foreach (var i in threes)
                Console.WriteLine($"{i}");

            int[] arer = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
          var  radfadfes = arer.Count(i => i % 2 != 0);
            Console.WriteLine(radfadfes);

            var custmoerorder = CustomerList.Select(i => new { customer = i, orders = i.Orders.Count() });

            foreach (var i in custmoerorder)
                Console.WriteLine($"{i}");


            var countproducts = ProductList.GroupBy(i => i.Category).Select(i => new { category = i.Key, count = i.Count() });
            foreach (var i in countproducts)
                Console.WriteLine($"{i}");

            int[] ar = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var sumer = ar.Sum();
            Console.WriteLine($"{sumer}");

            string[] dict = System.IO.File.ReadAllLines("dictionary_english.txt");
            var letterno = dict.Select(i => i.Count()).Sum();

            Console.WriteLine($"{letterno}");

            var productunitinstock = ProductList.Sum(i => i.UnitsInStock);
            Console.WriteLine($"{productunitinstock}");

            var smallest = dict.Min(i => i.Count());

            Console.WriteLine($"{smallest}");

            var cheap1 = ProductList.GroupBy(p => p.Category).Select(i => i.Min(P => P.UnitPrice));
            foreach (var c in cheap1)

                Console.WriteLine(c);
            var stockCount = from P in ProductList
                             group P by P.Category into c
                             let stockSum = c.Sum(P => P.UnitsInStock)
                             select new { Category = c.Key, totalUnits = stockSum };
            foreach (var hhh in stockCount)
                Console.WriteLine($"{hhh}");
            Console.WriteLine();


            var cheapeast = from P in ProductList
                            group P by P.Category into Cat
                            let cc = Cat.Min(P => P.UnitPrice)
                            select new { Category = Cat.Key, Cheapest = cc };
            foreach (var c in cheapeast)
            {
                Console.WriteLine(c);
            }

            var longest = dict.Max(W => W.Count());

            Console.WriteLine($"{longest}");

            var expensive = ProductList.GroupBy(p => p.Category).Select(C => C.Max(P => P.UnitPrice));
            foreach (var c in expensive)
            {
                Console.WriteLine(c);
            }


            var mostexp = from P in ProductList
                          group P by P.Category into Cat
                          let exp = Cat.Max(P => P.UnitPrice)
                          select new { Category = Cat.Key, MostExpensive = exp };
            foreach (var c in mostexp)
            {
                Console.WriteLine(c);
            }

            var sec = dict.Select(W => W.Count());
            var avg = sec.Average();
            Console.WriteLine($"{avg}");


            var avgproduct = ProductList.GroupBy(x => x.Category).Select(z => z.Average(P => P.UnitPrice)); ;
            Console.WriteLine($"{avgproduct}");

            var srtprod = ProductList.OrderBy(P => P.ProductName);
            foreach (var c in srtprod)
            {
                Console.WriteLine(c);

            }

            string[] arz = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            casecompare cer = new casecompare();
            var srted = arz.OrderBy(W => W, cer);
            foreach (var c in srted)
            {
                Console.WriteLine(c);
            }

            var sortunits = ProductList.OrderByDescending(P => P.UnitsInStock);
            foreach (var c in sortunits)
            {
                Console.WriteLine(c);

            }

            string[] arrrrr = { "zero", "one", "two", "three", "four",
                              "five", "six", "seven", "eight", "nine" };

            var startdigit = arrrrr.OrderBy(D => D.Count()).ThenBy(D => D);

            foreach (var c in startdigit)
            {
                Console.WriteLine(c);

            }
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var strtbylen = words.OrderBy(W => W.Count()).ThenBy(W => W, cer);

            foreach (var c in strtbylen)
            {
                Console.WriteLine(c);

            }


            var strtbyprice = ProductList.OrderBy(P => P.Category).ThenByDescending(P => P.UnitPrice);
            foreach (var c in strtbyprice)
            {
                Console.WriteLine(c);

            }

            var strtword = words.OrderBy(D => D.Count()).ThenByDescending(D => D, cer);

            foreach (var c in strtword)
            {
                Console.WriteLine(c);

            }
            string[] asd = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            List<String> adwad = asd.ToList();
            var strl = asd.Where(D => D[1] == 'i').OrderByDescending(D => adwad.IndexOf(D));

            foreach (var c in strl)
            {
                Console.WriteLine(c);
            }

            var prodname = ProductList.Select(P => P.ProductName);

            foreach (var c in prodname)
            {
                Console.WriteLine(c);
            }

            string[] wordsarr = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wvar = wordsarr.Select(P => new { Upper = P.ToUpper(), Lower = P.ToLower() });

            foreach (var c in wvar)
            {
                Console.WriteLine(c);
            }

            var newprod = ProductList.Select(P => new { price = P.UnitPrice, id = P.ProductID, name = P.ProductName });

            foreach (var c in newprod)
            {
                Console.WriteLine(c);
            }

            int[] ararar = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var vallal = ararar.Select((D, i) => D == i);

            foreach (var c in vallal)
            {
                Console.WriteLine(c);
            }

            int[] n1 = { 0, 2, 4, 5, 6, 8, 9 };
            int[] n2 = { 1, 3, 5, 7, 8 };

            var pairs = from A in n1
                        let B = n2
                        from item in B
                        where A < item
                        select A + " is smaller than " + item;

            foreach (var c in pairs)
            {

                Console.WriteLine(c);
            }


            var lless500 = CustomerList.SelectMany(C => C.Orders).Where(a => a.Total < 500);
            foreach (var c in lless500)
            {
                Console.WriteLine(c);
            }

            var a19 = CustomerList.SelectMany(C => C.Orders).Where(O => O.OrderDate.Year >= 1998);
            foreach (var c in a19)
            {
                Console.WriteLine(c);
            }

            bool haslet = dict.Any(W => W.Contains("ei"));
            Console.WriteLine($"{haslet}");


            var lessone = ProductList.GroupBy(P => P.Category).Where(C => C.Any(P => P.UnitsInStock < 1));
            foreach (var c in lessone)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
            }


            var alllin = ProductList.GroupBy(P => P.Category).Where(C => C.All(P => P.UnitsInStock > 0));
            foreach (var c in alllin)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
            }


            var seq = Enumerable.Range(0, 15);
            var asdasdasd = seq.GroupBy(N => N % 5);

            foreach (var c in asdasdasd)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
            }

            var awdawfeaf = dict.GroupBy(W => W[0]);


            foreach (var c in awdawfeaf)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
            }


            string[] f423 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            wordercomp pp = new wordercomp();
            var gwords = f423.GroupBy(W => W, pp);

            foreach (var c in gwords)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
            }
        }

    }
}

