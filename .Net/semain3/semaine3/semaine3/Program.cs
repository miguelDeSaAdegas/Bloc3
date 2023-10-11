// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using semaine3.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        NorthwindContext context = new NorthwindContext();

        //B - Queries
        //ex1
        /*Console.WriteLine("Choisissez une ville");

        string ville = Console.ReadLine();

        IQueryable<Customer> customers = from c in context.Customers
                                         where c.City == ville
                                         select c;

        Console.WriteLine("Customers in {0}", ville);
        foreach (Customer customer in customers)
        {
            Console.WriteLine("{0}:", customer.ContactName);
        }
        */

        //ex2
        /*IQueryable<Category> categories = from c in context.Categories
                                          where c.CategoryName == "Beverages" || c.CategoryName == "Condiments"
                                          select c;

        foreach (Category category in categories)
        {
            Console.WriteLine("Catégorie : {0}",category.CategoryName);
            foreach (Product product in category.Products)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        */

        //ex3
        /*IQueryable<Category> categories = from c in context.Categories
                                          .Include("Products")
                                          where c.CategoryName == "Beverages" || c.CategoryName == "Condiments"
                                          select c;

        foreach (Category category in categories)
        {
            Console.WriteLine("Catégorie : {0}", category.CategoryName);
            foreach (Product product in category.Products)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        */

        //ex4
        /*Console.WriteLine("Choisissez un client");

        string client = Console.ReadLine();

        var orders = from o in context.Orders
                        where o.ShippedDate != null && o.CustomerId == client
                        orderby o.OrderDate
                        select new
                        {
                            o.CustomerId,
                            o.OrderDate,
                            o.ShippedDate
                        };


        foreach (var order in orders)
        {
            Console.WriteLine("Customer ID : {0} OrderDate : {1} ShippedDate : {2}", order.CustomerId, order.OrderDate, order.ShippedDate);
        }
        */

        //ex5
        /*
        var reponse = from o in context.OrderDetails
                      group o by o.ProductId into grouped
                      orderby grouped.Key
                      select new
                      {
                          ProductId = grouped.Key,
                          Somme = grouped.Sum(o => o.Quantity * o.UnitPrice)
                      };

        foreach (var item in reponse)
        {
            Console.WriteLine("{0} ----> {1}",item.ProductId, item.Somme);
        }
        */

        //ex6

        /*var reponse = from e in context.Employees
                      where e.Territories.Any(t => t.Region.RegionDescription.Equals("Western"))
                      select new
                      {
                          e.FirstName,
                          e.LastName
                      };

        Console.WriteLine("Liste des employés de la région Western");
        foreach (var e in reponse)
        {
            Console.WriteLine("{0} {1}",e.FirstName, e.LastName);
        }
        */

        //ex7

        /*Console.WriteLine("Les territoires gérés par le supérieur de Suyama");

        var reponse = (from e in context.Employees
                      where e.LastName.Equals("Suyama")
                      select e.ReportsToNavigation.Territories).SingleOrDefault();

        foreach (Territory territory in reponse)
        {
            Console.WriteLine("{0}", territory.TerritoryDescription);
        }
        */

        //C - Updates
        //ex1

        /*foreach (Customer customer in (from c in context.Customers select c))
        {
            customer.ContactName = customer.ContactName.ToUpper();
        }

        context.SaveChanges();

        foreach (Customer customer in (from c in context.Customers select c)) 
        {
            Console.WriteLine(customer.ContactName);
        }
        */

        //D - Insert
        //ex1

        /*
        Console.WriteLine("Veuillez nous donnez le nom de votre nouvelle catégorie");

        String cat = Console.ReadLine();

        Category category = new Category();
        category.CategoryName = cat;

        context.Categories.Add(category);
        context.SaveChanges();

        Category rep = (from c in context.Categories
                  where c.CategoryName == cat
                  select c).SingleOrDefault();

        Console.WriteLine("category name : {0}",rep.CategoryName);
        */

        //E - Deletes
        //ex1

        /*
        context.Categories.Remove((from c in context.Categories 
                                   where c.CategoryName == "jhonny" 
                                   select c).SingleOrDefault());
        context.SaveChanges();

        IQueryable<Category> categories = from c in context.Categories
                                          where c.CategoryName == "jhonny"
                                          select c;

        if (categories.IsNullOrEmpty()) Console.WriteLine("suppression effectuée");
        else Console.WriteLine("suppression non effectuée");
         */

        //ex3
        Console.WriteLine("id employee to delete");

        int empToDelete = Int32.Parse(Console.ReadLine());

        Console.WriteLine("id employee who get his work");

        int empWhoGetOrders = Int32.Parse(Console.ReadLine());

        IQueryable<Order> orders = from o in context.Orders
                                   where o.EmployeeId == empToDelete
                                   select o;

        foreach (Order order in orders)
        {
            Console.WriteLine("order who is getting changed : {0}",order.OrderId);
            order.EmployeeId = empWhoGetOrders;
        }

        context.Employees.Remove((from e in context.Employees 
                                  where e.EmployeeId == empToDelete 
                                  select e).FirstOrDefault());

        context.SaveChanges();

        IQueryable<Order> ordersToCheck = from o in context.Orders
                                          where o.EmployeeId == empWhoGetOrders
                                          select o;

        foreach (Order order in ordersToCheck)
            Console.WriteLine("order who got changed : {0}", order.OrderId);

    }
}