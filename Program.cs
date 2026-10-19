using LinqMastery.Data;
using LinqMastery.Models;
using System.Collections;
using System.Linq;

namespace LinqMastery;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("LINQ Mastery Practice Project");
        Console.WriteLine("Uncomment one exercise method at a time in Main().");

        Exercise01_Filtering();
        Exercise02_Projection();
        Exercise03_SelectMany();
        Exercise04_Sorting();
        Exercise05_ElementOperators();
        Exercise06_Aggregation();
        Exercise07_AnyAll();
        Exercise08_Grouping();
        Exercise09_SetOperations();
        Exercise10_InnerJoin();
        Exercise11_LeftJoin();
        Exercise12_GroupJoin();
        Exercise13_Partitioning();
        Exercise14_QuantifiersAndMembership();
        Exercise15_StringAndNumericQueries();
        Exercise16_NestedQueries();
        Exercise17_CombinedQueries();
        Exercise18_DictionaryAndLookup();
        Exercise19_JoinOrdersAndCustomers();
        Exercise20_Reports();
    }

    // RULE: For every task, implement both styles where supported.
    // Use these labels to keep your work organised:
    // METHOD SYNTAX PRACTICE
    // QUERY SYNTAX PRACTICE

    static void Exercise01_Filtering()
    {
        var products = StoreData.Products;

        // Task 1: Find products priced above 5,000.
        // METHOD SYNTAX PRACTICE
        // TODO: products.Where(...)

        var add = products.Where(p => p.Price > 5000);
        foreach (var p in add)
            Console.WriteLine($"{p.ProductName}:{p.Price}");

        // QUERY SYNTAX PRACTICE
        // TODO: from p in products where ... select p
        var a = from p in products where p.Price >= 5000 select p;
        foreach (var p in a)
        {
            Console.WriteLine($"Product:{p.ProductName},price:{p.Price}");
        }


        // Task 2: Find Electronics products that are in stock.
        // METHOD SYNTAX PRACTICE
        // TODO: Where with &&

        var result = products.Where(p => p.Category == "Electronics" && p.Stock > 0);
        foreach (var p in result)
            Console.WriteLine($"{p.Category}:{p.Stock}");


        // QUERY SYNTAX PRACTICE
        // TODO: where with &&

        var method = from p in products where p.Category == "Electronics" && p.Stock > 0 select p;
        foreach (var p in method)
        {
            Console.WriteLine($"{p.Category}:{p.Stock}");
        }

        // Task 3: Find products priced between 1,000 and 20,000.
        // METHOD SYNTAX PRACTICE
        // TODO
        var m = products.Where(p => p.Price >= 1000 && p.Price <= 20000);
        foreach(var p in m)
        {
            Console.WriteLine($"{p.Price}");
        }
        // QUERY SYNTAX PRACTICE
        // TODO

        // Task 4: Find products whose names contain "Office".
        // METHOD SYNTAX PRACTICE
        // TODO: Contains()
        var s = products.Where(p=>p.ProductName.Contains("Office"));
        foreach(var p in s)
        {
            Console.WriteLine($"{p.ProductName}");
        }

        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise02_Projection()
    {
        var products = StoreData.Products;

        // Task 1: Select only product names.
        // METHOD SYNTAX PRACTICE
        // TODO: Select(...)
        var x = products.Select (p => p);
        foreach (var p in x)
        {
            Console.WriteLine($"{p.ProductName}");
        }
        // QUERY SYNTAX PRACTICE
        // TODO: select p.ProductName

        // Task 2: Return ProductName and Price using an anonymous type.
        // METHOD SYNTAX PRACTICE
        // TODO: Select(p => new { ... })

        // METHOD SYNTAX PRACTICE
        var b = products.Select(p => new {p.ProductName, p.Price});
        foreach(var p in b)
        {
            Console.WriteLine($"ProductName: {p.ProductName},price: {p.Price}");
        }

        // QUERY SYNTAX PRACTICE
        // TODO: select new { ... }

        // Task 3: Return ProductName, Price, and PriceWithTax (18%).
        // METHOD SYNTAX PRACTICE
        // TODO
        var c = products.Select(p => new { p.ProductName, p.Price, PriceWithTax = p.Price*1.18m });
        foreach(var p in c)
        {
            Console.WriteLine($"ProductName: {p.ProductName},Price: {p.Price},Pricewithtax: {p.PriceWithTax}");
        }
        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise03_SelectMany()
    {
        var batches = StoreData.TrainingBatches;
        var products = StoreData.Products;

        // Task 1: Flatten all training batches into one sequence.
        // METHOD SYNTAX PRACTICE
        // TODO: SelectMany()
        var d = batches.SelectMany(p => p);
        foreach(var p in d)
        {
            Console.WriteLine(p);
        }

        // QUERY SYNTAX PRACTICE
        // TODO: use two from clauses

        // Task 2: Get every product tag as one flat sequence.
        // METHOD SYNTAX PRACTICE
        // TODO
        var a1 = products.SelectMany(p => p.Tags);

        Console.WriteLine("--- Method Syntax: All Product Tags ---");
        foreach (var tag in a1)
        {
            Console.WriteLine(tag);
        }
        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise04_Sorting()
    {
        var products = StoreData.Products;

        // Task 1: Sort by price ascending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderBy()
        var g = products.OrderBy(p => p.Price);
        foreach (var p in g)
        {
            Console.WriteLine(
                $"Name: {p.ProductName}, Category: {p.Category}, Price: ₹{p.Price}"
            );
        }

        // QUERY SYNTAX PRACTICE
        // TODO: orderby

        // Task 2: Sort by price descending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderByDescending()
        var h = products.OrderByDescending(p => p.Price);
        foreach(var p in h)
            Console.WriteLine($"{p.ProductName} - ₹{p.Price}");


        // QUERY SYNTAX PRACTICE
        // TODO: orderby ... descending

        // Task 3: Sort by Category ascending, then Price descending.
        // METHOD SYNTAX PRACTICE
        // TODO: OrderBy().ThenByDescending()

        var m1 = products
      .OrderBy(p => p.Category)
      .ThenByDescending(p => p.Price);
        foreach (var p in m1)
        {
            Console.WriteLine($"{p.Category} - {p.ProductName} - ₹{p.Price}");
        }
        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise05_ElementOperators()
    {
        var products = StoreData.Products;

        // Task 1: Find the first product priced above 10,000.
        // METHOD SYNTAX PRACTICE
        // TODO: First()
        var method1 = products.First(p => p.Price > 10000);
        Console.WriteLine($"Method - First: {method1.ProductName}, ₹{method1.Price}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + First()

        // Task 2: Search for ProductId 999 safely.
        // METHOD SYNTAX PRACTICE
        // TODO: FirstOrDefault()
        var method2 = products.FirstOrDefault(p => p.ProductId == 999);
        Console.WriteLine(method2 == null
            ? "Method - Product 999 not found"
            : $"Method - Found: {method2.ProductName}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + FirstOrDefault()

        // Task 3: Find ProductId 3 using Single().
        // METHOD SYNTAX PRACTICE
        // TODO: Single()
        var method3 = products.Single(p => p.ProductId == 3);
        Console.WriteLine($"Method - Single: {method3.ProductName}");
        // QUERY SYNTAX PRACTICE
        // TODO: query + Single()
    }

    static void Exercise06_Aggregation()
    {
        var products = StoreData.Products;

        // Task 1: Count all products.
        // METHOD SYNTAX PRACTICE
        // TODO: Count()
        Console.WriteLine($"Method - Count: {products.Count()}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + Count()

        // Task 2: Calculate total stock.
        // METHOD SYNTAX PRACTICE
        // TODO: Sum()
        Console.WriteLine($"Method - Total Stock: {products.Sum(p => p.Stock)}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + Sum()

        // Task 3: Find average, minimum and maximum price.
        // METHOD SYNTAX PRACTICE
        // TODO

        Console.WriteLine($"Method - Average Price: {products.Average(p => p.Price)}");
        Console.WriteLine($"Method - Minimum Price: {products.Min(p => p.Price)}");
        Console.WriteLine($"Method - Maximum Price: {products.Max(p => p.Price)}");

        // QUERY SYNTAX PRACTICE
        // TODO

        // Task 4: Calculate total inventory value (Price * Stock).
        // METHOD SYNTAX PRACTICE
        // TODO
        Console.WriteLine($"Method - Inventory Value: {products.Sum(p => p.Price * p.Stock)}");


        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise07_AnyAll()
    {
        var products = StoreData.Products;

        // Task 1: Check whether any product costs more than 50,000.
        // METHOD SYNTAX PRACTICE
        // TODO: Any()
        var method1 = products.Any(p => p.Price > 50000);
        Console.WriteLine($"Method - Any above ₹50,000: {method1}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + Any()

        // Task 2: Check whether all products have non-negative stock.
        // METHOD SYNTAX PRACTICE
        // TODO: All()
        var method2 = products.All(p => p.Stock >= 0);
        Console.WriteLine($"Method - All stock non-negative: {method2}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + All()
    }

    static void Exercise08_Grouping()
    {
        var products = StoreData.Products;

        // Task 1: Group products by Category.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy()
        var method1 = products.GroupBy(p => p.Category);

        Console.WriteLine("--- Method: Group By Category ---");
        foreach (var group in method1)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"  {p.ProductName} - ₹{p.Price}");
        }

        // QUERY SYNTAX PRACTICE
        // TODO: group ... by ...

        // Task 2: For each category, calculate product count,
        // total stock, and average price.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy + Select

        var method2 = products.GroupBy(p => p.Category)
           .Select(g => new
           {
               Category = g.Key,
               ProductCount = g.Count(),
               TotalStock = g.Sum(p => p.Stock),
               AveragePrice = g.Average(p => p.Price)
           });

        foreach (var r in method2)
            Console.WriteLine($"{r.Category}: Count={r.ProductCount}, Stock={r.TotalStock}, Average=₹{r.AveragePrice:F2}");

        // QUERY SYNTAX PRACTICE
        // TODO: group ... by ... into ...
    }

    static void Exercise09_SetOperations()
    {
        var a = StoreData.ListA;
        var b = StoreData.ListB;

        // Task 1: Remove duplicates.
        // METHOD SYNTAX PRACTICE
        // TODO: Distinct()
        var method1 = a.Distinct();
        Console.WriteLine("Method - Distinct: " + string.Join(", ", method1));

        // QUERY SYNTAX PRACTICE
        // TODO: query + Distinct()

        // Task 2: Find union, intersection and A-only values.
        // METHOD SYNTAX PRACTICE
        // TODO: Union(), Intersect(), Except()
        Console.WriteLine("Method - Union: " + string.Join(", ", a.Union(b)));
        Console.WriteLine("Method - Intersect: " + string.Join(", ", a.Intersect(b)));
        Console.WriteLine("Method - A-only: " + string.Join(", ", a.Except(b)));


        // QUERY SYNTAX PRACTICE
        // TODO: query results + set operators
    }

    static void Exercise10_InnerJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Display EmployeeName and DepartmentName for matching records.
        // METHOD SYNTAX PRACTICE
        // TODO: Join()
        var method = employees.Join(
    departments,
    e => e.DepartmentId,
    d => d.DepartmentId,
    (e, d) => new
    {
        e.EmployeeName,
        d.DepartmentName
    });

        foreach (var x in method)
            Console.WriteLine($"{x.EmployeeName} - {x.DepartmentName}");

        // QUERY SYNTAX PRACTICE
        // TODO: join ... on ... equals ...
    }

    static void Exercise11_LeftJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return every employee, displaying "Unassigned" if
        // no matching department exists.
        // METHOD SYNTAX PRACTICE
        // TODO: LeftJoin() on .NET 10, or GroupJoin + SelectMany

        var method = employees.GroupJoin(
       departments,
       e => e.DepartmentId,
       d => d.DepartmentId,
       (e, ds) => new { e, ds })
       .SelectMany(
           x => x.ds.DefaultIfEmpty(),
           (x, d) => new
           {
               x.e.EmployeeName,
               DepartmentName = d == null
                   ? "Unassigned"
                   : d.DepartmentName
           });

        foreach (var x in method)
            Console.WriteLine($"{x.EmployeeName} - {x.DepartmentName}");


        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ... then DefaultIfEmpty()
    }

    static void Exercise12_GroupJoin()
    {
        var employees = StoreData.Employees;
        var departments = StoreData.Departments;

        // Task: Return each department with its employee count.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupJoin()
        var method = departments.GroupJoin(
        employees,
        d => d.DepartmentId,
        e => e.DepartmentId,
        (d, es) => new
        {
            d.DepartmentName,
            EmployeeCount = es.Count()
        });

        foreach (var x in method)
            Console.WriteLine($"{x.DepartmentName} - Employees: {x.EmployeeCount}");

        // QUERY SYNTAX PRACTICE
        // TODO: join ... into ...
    }

    static void Exercise13_Partitioning()
    {
        var products = StoreData.Products.OrderBy(p => p.ProductId);

        // Task 1: Get first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Take(3)
        var method1 = products.Take(3);
        Console.WriteLine("--- Method: Take(3) ---");
        foreach (var p in method1)
            Console.WriteLine($"{p.ProductId} - {p.ProductName}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + Take(3)

        // Task 2: Skip first three products.
        // METHOD SYNTAX PRACTICE
        // TODO: Skip(3)
        var method2 = products.Skip(3);
        Console.WriteLine("--- Method: Skip(3) ---");
        foreach (var p in method2)
            Console.WriteLine($"{p.ProductId} - {p.ProductName}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + Skip(3)
    }

    static void Exercise14_QuantifiersAndMembership()
    {
        List<int> requestedIds = new() { 1, 3, 5 };

        // Task: Find products whose IDs occur in requestedIds.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + Contains
        var products = StoreData.Products;
        var b1 = products.Where(p => requestedIds.Contains(p.ProductId));

        foreach (var p in b1)
            Console.WriteLine($"Method: {p.ProductId} - {p.ProductName}");


        // QUERY SYNTAX PRACTICE
        // TODO: where + Contains
    }

    static void Exercise15_StringAndNumericQueries()
    {
        var products = StoreData.Products;

        // Task 1: Find names starting with "O".
        // METHOD SYNTAX PRACTICE
        // TODO: StartsWith()
        var method1 = products.Where(p =>
       p.ProductName.StartsWith("O"));

        foreach (var p in method1)
            Console.WriteLine($"Method - Starts with O: {p.ProductName}");


        // QUERY SYNTAX PRACTICE
        // TODO

        // Task 2: Find products with even ProductIds.
        // METHOD SYNTAX PRACTICE
        // TODO: modulo operator %
        var method2 = products.Where(p => p.ProductId % 2 == 0);

        foreach (var p in method2)
            Console.WriteLine($"Method - Even ID: {p.ProductId} - {p.ProductName}");


        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise16_NestedQueries()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;
        var customers = StoreData.Customers;

        // Task 1: Find products priced above average.
        // METHOD SYNTAX PRACTICE
        // TODO: Average + Where
        var averagePrice = products.Average(p => p.Price);
        var method1 = products.Where(p => p.Price > averagePrice);

        foreach (var p in method1)
            Console.WriteLine($"Method - Above average: {p.ProductName} - ₹{p.Price}");

        // QUERY SYNTAX PRACTICE
        // TODO

        // Task 2: Find customers with at least one order.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + Any
        var method2 = customers.Where(c =>
       orders.Any(o => o.CustomerId == c.CustomerId));

        foreach (var c in method2)
            Console.WriteLine($"Method - Has order: {c.CustomerName}");

        // QUERY SYNTAX PRACTICE
        // TODO
    }

    static void Exercise17_CombinedQueries()
    {
        var products = StoreData.Products;

        // Task: Find in-stock Electronics products, sort by descending
        // price, and return only product names.
        // METHOD SYNTAX PRACTICE
        // TODO: Where + OrderByDescending + Select
        var method = products
       .Where(p => p.Category == "Electronics" && p.Stock > 0)
       .OrderByDescending(p => p.Price)
       .Select(p => p.ProductName);

        Console.WriteLine("--- Method Syntax ---");
        foreach (var name in method)
            Console.WriteLine(name);

        // QUERY SYNTAX PRACTICE
        // TODO: from + where + orderby + select
    }

    static void Exercise18_DictionaryAndLookup()
    {
        var products = StoreData.Products;

        // Task 1: Create a dictionary keyed by ProductId.
        // METHOD SYNTAX PRACTICE
        // TODO: ToDictionary()
        var method1 = products.ToDictionary(p => p.ProductId);

        Console.WriteLine("--- Method Dictionary ---");
        foreach (var item in method1)
            Console.WriteLine($"ID: {item.Key}, Product: {item.Value.ProductName}");

        // QUERY SYNTAX PRACTICE
        // TODO: query + ToDictionary()

        // Task 2: Create a lookup by Category.
        // METHOD SYNTAX PRACTICE
        // TODO: ToLookup()
        var method2 = products.ToLookup(p => p.Category);

        Console.WriteLine("--- Method Lookup ---");
        foreach (var group in method2)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"  {p.ProductName}");
        }
        // QUERY SYNTAX PRACTICE
        // TODO: query + ToLookup()
    }

    static void Exercise19_JoinOrdersAndCustomers()
    {
        var orders = StoreData.Orders;
        var customers = StoreData.Customers;

        // Task: Show OrderId, CustomerName, OrderDate and Status.
        // METHOD SYNTAX PRACTICE
        // TODO: Join + Select
        var method = orders.Join(
        customers,
        o => o.CustomerId,
        c => c.CustomerId,
        (o, c) => new
        {
            o.OrderId,
            c.CustomerName,
            o.OrderDate,
            o.Status
        });

        foreach (var x in method)
            Console.WriteLine(
                $"Order: {x.OrderId}, Customer: {x.CustomerName}, Date: {x.OrderDate}, Status: {x.Status}");


        // QUERY SYNTAX PRACTICE
        // TODO: join + select
    }

    static void Exercise20_Reports()
    {
        var products = StoreData.Products;
        var orders = StoreData.Orders;

        // Task 1: Count orders by Status.
        // METHOD SYNTAX PRACTICE
        // TODO: GroupBy + Count
        var method1 = orders.GroupBy(o => o.Status)
       .Select(g => new
       {
           Status = g.Key,
           Count = g.Count()
       });

        Console.WriteLine("--- Method: Orders by Status ---");
        foreach (var x in method1)
            Console.WriteLine($"{x.Status}: {x.Count}");

        // QUERY SYNTAX PRACTICE
        // TODO: group by + Count

        // Task 2: Create a category report with product count,
        // average price, total stock and inventory value.
        // METHOD SYNTAX PRACTICE
        // TODO
        var method2 = products.GroupBy(p => p.Category)
       .Select(g => new
       {
           Category = g.Key,
           ProductCount = g.Count(),
           AveragePrice = g.Average(p => p.Price),
           TotalStock = g.Sum(p => p.Stock),
           InventoryValue = g.Sum(p => p.Price * p.Stock)
       });

        Console.WriteLine("--- Method: Category Report ---");
        foreach (var x in method2)
            Console.WriteLine(
                $"{x.Category}: Count={x.ProductCount}, Average=₹{x.AveragePrice:F2}, Stock={x.TotalStock}, Value=₹{x.InventoryValue:F2}");



        // QUERY SYNTAX PRACTICE
        // TODO
    }
}
