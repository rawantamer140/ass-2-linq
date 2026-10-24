namespace ass_2_linq 
{


    using static LINQ.DataSources.Source;


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            // --𝟷
            var result1 = ProductList
                .OrderByDescending(p => p.UnitPrice)
                .Take(3);

            // --𝟸
            var result2 = ProductList
                .OrderBy(p => p.ProductID)
                .Skip(5)
                .Take(5);

            // --𝟹
            var result3 = ProductList
                .OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);

            // --𝟺
            var result4 = ProductList
                .Where(p => p.Category == "Seafood")
                .All(p => p.UnitsInStock > 0);

            // --𝟻
            int[] ids = { 3, 9, 13, 18 };

            var result5 = ids.Contains(9);

            // --𝟼
            var result6 = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductCount = g.Count()
                });

            foreach (var group in result6)
            {
                Console.WriteLine($"{group.Category}: {group.ProductCount}");
            }

            // --𝟽
            var result7 = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductNames = g.Select(p => p.ProductName)
                });

            // --𝟾
            var result8 = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Count() > 3)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductCount = g.Count()
                });

            // --𝟿
            var result9 =
                from c in CustomerList
                group c by c.Country into g
                select new
                {
                    Country = g.Key,
                    Count = g.Count(),
                    TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                };

            // --𝟷𝟶
            var result10 = ProductList
                .Sum(p => p.UnitsInStock);

            // --𝟷𝟷
            var cheapest = ProductList.Min(p => p.UnitPrice);
            var mostExpensive = ProductList.Max(p => p.UnitPrice);

            // --𝟷𝟸
            var result12 = ProductList
                .Select(p => p.Category)
                .Distinct();

            // --𝟷𝟹
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var result13 = setA.Except(setB);
        }
    }
}
